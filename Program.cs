using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProducto, ProductoServices>();
builder.Services.AddScoped<ICatalogo, CatalogoServices>();
builder.Services.AddScoped<ICliente, CLienteServices>();
builder.Services.AddScoped<IVenta, VentaServcies>();

builder.Services.AddDbContext<MasterclassContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
