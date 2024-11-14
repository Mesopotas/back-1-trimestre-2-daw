
using Microsoft.AspNetCore.Mvc;
using Models;

namespace back_1_trimestre_2_daw.Controllers{

[ApiController]
[Route("MinimalCinema/[controller]")]
public class PeliculaController : ControllerBase
{
    private static List<Pelicula> peliculas = new List<Pelicula>();

    public PeliculaController(){
        if(peliculas.Count == 0){
            InicializarDatos();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pelicula>> GetAll()

        {
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public ActionResult<Pelicula> GetById(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id_Pelicula == id);
            if (pelicula == null)
                return NotFound();
            return Ok(pelicula);
        
        }
        [HttpGet("categoria")]
        public ActionResult<IEnumerable<Pelicula>> GetByCategory([FromQuery] int idCategoria)
        {
            var peliculasCategoria = peliculas.Where(p => p.Id_Categoria == idCategoria).ToList();
            if (!peliculasCategoria.Any())
                return NotFound("No se encontraron películas en la categoría especificada.");
            return Ok(peliculasCategoria);
        }

        [HttpPost]
        public ActionResult<Pelicula> Create([FromBody] Pelicula pelicula)
        {
            peliculas.Add(pelicula);
            return CreatedAtAction(nameof(GetById), new { id = pelicula.Id_Pelicula }, pelicula);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Pelicula updatedPelicula)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id_Pelicula == id);
            if (pelicula == null)
                return NotFound();

            pelicula.Nombre = updatedPelicula.Nombre;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pelicula = peliculas.FirstOrDefault(p => p.Id_Pelicula == id);
            if (pelicula == null)
                return NotFound();

            peliculas.Remove(pelicula);
            return NoContent();
        }

        private static void InicializarDatos()
        {
            peliculas.Add(new Pelicula(1, "Terrifier", "muymucho miedo", "Leonardo DiCaprio y Selena Gomez", "Nicolas Abuin", 2.1, 7.5, false,1,"Terror"));
            peliculas.Add(new Pelicula(2, "Unbeso", "muymucho miedo", "Leonardo DiCaprio y Selena Gomez", "Nicolas Abuin", 2.1, 7.5, false,3,"Romance"));
        }
    }
}

