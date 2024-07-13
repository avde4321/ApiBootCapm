using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Interfaces
{
    public interface IVenta
    {
        Task<Respuesta> GetVenta(string? numFactura, string fechaDesde, string fechaHasta);
        Task<Respuesta> GetVentaReporte();
        Task<Respuesta> PosVenta(Venta venta);
        Task<Respuesta> PutVenta(Venta venta);
    }
}
