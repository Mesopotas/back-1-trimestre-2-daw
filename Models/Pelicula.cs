namespace Models;

public class Pelicula : Categoria{

    public int Id_Pelicula{get; set;}
    public string Nombre {get; set;}
    public string Descripcion {get; set;}    
    public string Actores {get; set;}
    public string Directores {get; set;}
    public string Duracion {get; set;}
    public double Precio {get; set;}


    public Pelicula(int id_pelicula, string nombre, string descripcion, string actores, string directores, string duracion, double precio, int id_categoria, string nombre_categoria): base(id_categoria, nombre_categoria){

        Id_Pelicula = id_pelicula;
        Nombre = nombre;
        Descripcion = descripcion;
        Actores = actores;
        Directores = directores;
        Duracion = duracion;
        Precio = precio;

    }

    public override void MostrarDetalles(){

    }


}