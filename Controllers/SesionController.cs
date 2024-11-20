using Microsoft.AspNetCore.Mvc;
using Models;

namespace back_1_trimestre_2_daw.Controllers
{
    [ApiController]
    [Route("MinimalCinema/[controller]")]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();

    public SesionController()
    {
        if (PeliculaController.GetPeliculas().Count == 0)
        {
            new PeliculaController();
        }

        if (SalaController.GetSalas().Count == 0)
        {
            new SalaController();
        }

        if (sesiones.Count == 0)
        {
            InicializarSesiones();
        }
    }


        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetAll()
        {
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesion> GetById(int id)
        {
            var sesion = sesiones.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
                return NotFound();
            return Ok(sesion);
        }

        [HttpGet("pelicula/{idPelicula}/salas")]
        public ActionResult<IEnumerable<Sala>> GetSalasByPelicula(int idPelicula)
        {
            // Filtrar las sesiones por el ID de la película
            var salas = sesiones
                .Where(s => s.Pelicula.Id_Pelicula == idPelicula)
                .Select(s => s.Sala)
                .Distinct()
                .ToList();

            if (!salas.Any())
            {
                return NotFound($"No se encontraron salas para la película con ID {idPelicula}.");
            }

            return Ok(salas);
        }

        private static void InicializarSesiones()
        {

            var peliculas = PeliculaController.GetPeliculas();
            var salas = SalaController.GetSalas();

            // Asociar películas con salas para crear sesiones
            if (peliculas.Count > 0 && salas.Count > 0)
            {
                sesiones.Add(new Sesion(1, peliculas[1], salas[0]));
                sesiones.Add(new Sesion(2, peliculas[2], salas[1]));
                sesiones.Add(new Sesion(3, peliculas[3], salas[2]));
            }
        }
    }
}
