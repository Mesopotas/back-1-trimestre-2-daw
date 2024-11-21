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

            if (HorarioController.GetHorarios().Count == 0)
            {
                new HorarioController();
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
            var horarios = HorarioController.GetHorarios();

            // Asociar películas, salas y horarios para crear sesiones
            if (peliculas.Count > 0 && salas.Count > 0 && horarios.Count > 0)
            {
                sesiones.Add(new Sesion(1, peliculas[0], salas[0], horarios[0])); // Película 1, Sala 1, Horario 1
                sesiones.Add(new Sesion(2, peliculas[1], salas[1], horarios[1])); // Película 2, Sala 2, Horario 2
                sesiones.Add(new Sesion(3, peliculas[2], salas[2], horarios[2])); // Película 3, Sala 3, Horario 3
            }
        }
    }
}
