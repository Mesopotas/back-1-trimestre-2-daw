using Models;

public class Sesion
{
    public int Id { get; set; }
    public Pelicula Pelicula { get; set; }
    public Sala Sala { get; set; }

    public Sesion(int id, Pelicula pelicula, Sala sala)
    {
        Id = id;
        Pelicula = pelicula;
        Sala = sala;
    }
}
