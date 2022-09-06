using ApiToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adicionando Servi�os do controller
builder.Services.AddDbContext<AppDbContext>(); // Transformando o AppDbContext em um servi�o

var app = builder.Build();

app.MapControllers(); // Mapeando os controllers

app.Run();