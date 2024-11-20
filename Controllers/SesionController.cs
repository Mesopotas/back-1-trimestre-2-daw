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
            new PeliculaController(); // Inicializa películas si no están inicializadas
        }

        if (SalaController.GetSalas().Count == 0)
        {
            new SalaController(); // Inicializa salas si no están inicializadas
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

        private static void InicializarSesiones()
        {
            // Obtener datos inicializados desde PeliculaController y SalaController
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
