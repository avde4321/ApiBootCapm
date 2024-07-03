using EjemploEntity.DTOs;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetListaProductos(int productoID, float precio);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
    }
}
