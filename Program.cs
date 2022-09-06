using ApiToDoList.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Adicionando Serviços do controller
builder.Services.AddDbContext<AppDbContext>(); // Transformando o AppDbContext em um serviço

var app = builder.Build();

app.MapControllers(); // Mapeando os controllers

app.Run();