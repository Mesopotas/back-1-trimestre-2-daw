namespace Models;

abstract class Pelicula{

    public string Nombre {get; set;}
    public string Descripcion {get; set;}    
    public string Actores {get; set;}
    public string Directores {get; set;}
    public string Duracion {get; set;}
    public double Precio {get; set;}


    public Pelicula(string nombre, string descripcion, string actores, string directores, string duracion, double precio){

        Nombre = nombre;
        Descripcion = descripcion;
        Actores = actores;
        Directores = directores;
        Duracion = duracion;
        Precio = precio;

    }

    public abstract void MostrarDetalles();


}