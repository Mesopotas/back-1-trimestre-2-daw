using Models;
/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

*/


//////////////////////////////////////////////////////


//Para crear una nueva pelicua, necesitaras, su Id(int), su Nombre, su descripcion, los actores, Directores, Duracion(double), Precio(doble), Id_categoria(int), Nombre_categoria

var pelicula = new Pelicula(1, "Terrifier", "muymucho miedo", "y0", "yo", 2.1, 7.5, 1,"Miedo");

pelicula.MostrarDetalles();


