
using Microsoft.AspNetCore.Mvc;
using Models;

namespace back_1_trimestre_2_daw.Controllers{

[ApiController]
[Route("MinimalCinema/[controller]")]
public class CategoriaController : ControllerBase
{
    private static List<Categoria> categorias = new List<Categoria>();

    public CategoriaController(){
        if(categorias.Count == 0){
            InicializarDatos();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetAll()

        {
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            var categoria = categorias.FirstOrDefault(p => p.Id_Categoria == id);
            if (categoria == null)
                return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult<Categoria> Create([FromBody] Categoria categoria)
        {
            categorias.Add(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id_Categoria }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Categoria updatedCategoria)
        {
            var categoria = categorias.FirstOrDefault(p => p.Id_Categoria == id);
            if (categoria == null)
                return NotFound();

            categoria.Nombre_Categoria = updatedCategoria.Nombre_Categoria;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = categorias.FirstOrDefault(p => p.Id_Categoria == id);
            if (categoria == null)
                return NotFound();

            categorias.Remove(categoria);
            return NoContent();
        }

        private static void InicializarDatos()
        {
            categorias.Add(new Categoria(1, "Estrenos"));
            categorias.Add(new Categoria(2, "Aventura"));
            categorias.Add(new Categoria(3, "Terror"));
            categorias.Add(new Categoria(4, "Ciencia Ficción"));
            categorias.Add(new Categoria(5, "Animación"));
        }
    }
}

