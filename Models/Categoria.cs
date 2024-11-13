namespace Models;

public class Categoria{

    public int Id_Categoria {get; set;}
    public string Nombre_Categoria {get; set;}

    public Categoria(int id_categoria, string nombre_categoria){
        Id_Categoria = id_categoria;
        Nombre_Categoria = nombre_categoria;
    }



    

}