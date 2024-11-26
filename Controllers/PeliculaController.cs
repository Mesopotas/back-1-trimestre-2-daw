using Microsoft.AspNetCore.Mvc;
using Models;

namespace back_1_trimestre_2_daw.Controllers
{
    [ApiController]
    [Route("MinimalCinema/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private static List<Pelicula> peliculas = new List<Pelicula>();

        public PeliculaController()
        {
            if (peliculas.Count == 0)
            {
                InicializarPeliculas();
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


        
        private static void InicializarPeliculas()
        { 
            peliculas.Add(new Pelicula(1, "Spider-man homecoming", "Peter Parker comienza a experimentar su recién descubierta identidad como Spiderman. Tras su experiencia con los Vengadores, regresa a vivir con su tía. Pero su rutina se ve interrumpida al surgir un nuevo y despiadado villano, el Buitre, que amenaza lo más importante en la vida de Peter.", "Tom Holland, Marisa Tomei y Tyle Daly", "Jon Watts", 2.13, 4.50, "16","../images/Spider-Man-Homecoming.png", 1, "Acción"));
            peliculas.Add(new Pelicula(2, "Inception", "Un ladrón que roba secretos corporativos a través del uso de la tecnología de sueño compartido se enfrenta a la tarea imposible de plantar una idea en la mente de un director ejecutivo.", "Leonardo DiCaprio, Joseph Gordon-Levitt y Ellen Page", "Christopher Nolan", 2.28, 5.00, "18","../images/Inception.png", 1, "Acción"));
            peliculas.Add(new Pelicula(3, "El Rey León", "Tras la muerte de su padre, un joven león huye de su reino solo para aprender el verdadero significado de responsabilidad y valentía.", "Matthew Broderick, Jeremy Irons y James Earl Jones", "Roger Allers", 1.58, 3.00, "1","../images/El-Rey-Leon.png", 2, "Animación"));
            peliculas.Add(new Pelicula(4, "The Dark Knight", "Cuando el caos es desatado en Gotham City por el Joker, Batman debe enfrentarse a uno de los mayores desafíos de su vida.", "Christian Bale, Heath Ledger y Aaron Eckhart", "Christopher Nolan", 2.32, 5.50, "18","../images/The-Dark-Knight.png", 1, "Acción"));
            peliculas.Add(new Pelicula(5, "Frozen", "Anna, una joven valiente, emprende un viaje épico para encontrar a su hermana Elsa, cuyos poderes han sumido al reino en un invierno eterno.", "Kristen Bell, Idina Menzel y Josh Gad", "Chris Buck", 1.42, 3.50, "6","../images/Frozen.png", 2, "Animación"));
            peliculas.Add(new Pelicula(6, "Avatar", "Un exmarine parapléjico es enviado a Pandora en una misión única, pero se debate entre seguir órdenes o proteger el mundo que siente como suyo.", "Sam Worthington, Zoe Saldana y Sigourney Weaver", "James Cameron", 2.42, 6.00, "12","../images/Frozen.png", 3, "Ciencia ficción"));
            peliculas.Add(new Pelicula(7, "Toy Story", "Un vaquero de juguete se siente amenazado por la llegada de un astronauta de plástico que parece reemplazarlo en la vida de su dueño.", "Tom Hanks, Tim Allen y Don Rickles", "John Lasseter", 1.21, 3.00, "6","../images/Toy-Story.png", 2, "Animación"));
            peliculas.Add(new Pelicula(8, "Jurassic Park", "Un parque temático lleno de dinosaurios clonados se convierte en una pesadilla cuando sus sistemas de seguridad fallan.", "Sam Neill, Laura Dern y Jeff Goldblum", "Steven Spielberg", 2.07, 5.50, "12","../images/Jurassic-Park.png", 3, "Ciencia ficción"));
            peliculas.Add(new Pelicula(9, "Titanic", "Un artista pobre y una joven de clase alta se enamoran durante el fatídico viaje inaugural del Titanic.", "Leonardo DiCaprio, Kate Winslet y Billy Zane", "James Cameron", 3.14, 5.00, "16","../images/Titanic.png", 4, "Romance"));
            peliculas.Add(new Pelicula(10, "Shrek", "Un ogro gruñón y un burro parlanchín parten en una misión para rescatar a una princesa atrapada en una torre custodiada por un dragón.", "Mike Myers, Eddie Murphy y Cameron Diaz", "Andrew Adamson", 1.35, 3.50, "3", "../images/Shrek.png", 2, "Animación"));
            peliculas.Add(new Pelicula(11, "El Padrino", "El patriarca de una familia criminal transfiere el control de su imperio a su hijo menor, con consecuencias trágicas.", "Marlon Brando, Al Pacino y James Caan", "Francis Ford Coppola", 2.55, 5.50, "18","../images/Shrek.png", 5, "Drama"));
            peliculas.Add(new Pelicula(12, "Avengers: Endgame", "Después de la devastación causada por Thanos, los Vengadores restantes intentan revertir el daño y restaurar el orden en el universo.", "Robert Downey Jr., Chris Evans y Scarlett Johansson", "Anthony y Joe Russo", 3.01, 6.00, "12","../images/Avengers-Endgame.png", 1, "Acción"));
            peliculas.Add(new Pelicula(13, "Coco", "Un niño apasionado por la música se embarca en una extraordinaria aventura en la Tierra de los Muertos para descubrir los secretos de su familia.", "Anthony Gonzalez, Gael García Bernal y Benjamin Bratt", "Lee Unkrich", 1.45, 3.50, "3","../images/Coco.png", 2, "Animación"));
            peliculas.Add(new Pelicula(14, "Matrix", "Un programador descubre la verdad sobre su realidad y su papel en la guerra contra sus controladores.", "Keanu Reeves, Laurence Fishburne y Carrie-Anne Moss", "Lana Wachowski y Lilly Wachowski", 2.16, 5.00, "16","../images/Matrix.png", 3, "Ciencia ficción"));
            peliculas.Add(new Pelicula(15, "Buscando a Nemo", "Un pez payaso sobreprotector cruza el océano para rescatar a su hijo capturado.", "Albert Brooks, Ellen DeGeneres y Alexander Gould", "Andrew Stanton", 1.40, 3.50, "3","../images/Buscando-A-Nemo.png", 2, "Animación"));
            peliculas.Add(new Pelicula(16, "Gladiator", "Un general romano caído en desgracia se convierte en gladiador para vengarse del emperador corrupto que asesinó a su familia.", "Russell Crowe, Joaquin Phoenix y Connie Nielsen", "Ridley Scott", 2.35, 5.50, "18","../images/Gladiator.png", 5, "Drama"));
            peliculas.Add(new Pelicula(17, "Moana", "Una joven polinesia se embarca en una misión para salvar a su isla, con la ayuda de un semidiós arrogante.", "Auli’i Cravalho, Dwayne Johnson y Rachel House", "Ron Clements", 1.47, 3.50, "3","../images/Moana.png", 2, "Animación"));
            peliculas.Add(new Pelicula(18, "El Grinch", "El Grinch, una criatura verde y gruñona que vive en una cueva, planea arruinar la Navidad robando los regalos y decoraciones de los habitantes de Villa Quién. Sin embargo, una niña con espíritu navideño lo ayudará a cambiar su perspectiva.", "Benedict Cumberbatch, Rashida Jones y Cameron Seely", "Yarrow Cheney y Scott Mosier", 1.30, 3.50, "6","../images/El_Grinch.png", 2, "Animación"));
            peliculas.Add(new Pelicula(19, "Black Panther", "T’Challa hereda el trono de Wakanda y debe enfrentarse a un antiguo enemigo que pone en peligro a su pueblo.", "Chadwick Boseman, Michael B. Jordan y Lupita Nyong’o", "Ryan Coogler", 2.15, 5.00, "12","../images/Black-Panter.png", 1, "Acción"));
            peliculas.Add(new Pelicula(20, "Star Wars: Episodio IV", "Un joven granjero se une a un caballero Jedi, un contrabandista y una princesa para luchar contra un malvado imperio galáctico.", "Mark Hamill, Harrison Ford y Carrie Fisher", "George Lucas", 2.01, 4.50, "16","../images/Star-Wars-Episodio-4.png", 3, "Ciencia ficción"));

        }

        
        public static List<Pelicula> GetPeliculas()
        {
            return peliculas;
        }

    }
}

