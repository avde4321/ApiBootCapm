using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class VentaServcies : IVenta
    {
        private readonly MasterclassContext _context;

        public VentaServcies(MasterclassContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                IQueryable<VentaDto> query = (from v in _context.Ventas
                                              join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                              join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                              join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                              join ct in _context.Categoria on v.CategId equals ct.CategId
                                              join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                              select new VentaDto
                                              {
                                                  IdFactura = v.IdFactura,
                                                  NumFact = v.NumFact,
                                                  FechaHora = v.FechaHora,
                                                  ClienteDetalle = cl.ClienteNombre,
                                                  ProductoDetalle = pr.ProductoDescrip,
                                                  ModeloDetalle = mo.ModeloDescripción,
                                                  CategDetalle = ct.CategNombre,
                                                  SucursalDetalle = sc.SucursalNombre,
                                                  Caja = v.Caja,
                                                  Vendedor = v.Vendedor,
                                                  Precio = v.Precio,
                                                  Unidades = v.Unidades,
                                                  Estado = v.Estado
                                              }).AsQueryable();


                if (numFactura != null && numFactura != "0")
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.NumFact.Equals(numFactura) && x.Estado.Equals("Registrada")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("Registrada")).ToListAsync(); ;
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        public async Task<Respuesta> PosVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Ventas.OrderByDescending(x => x.IdFactura).Select(x => x.IdFactura).FirstOrDefault();

                venta.IdFactura = Convert.ToInt32(query) + 1;
                venta.FechaHora = DateTime.Now;

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                respuesta.Cod = "000";
                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se generado una novedad, Error: {ex.Message}";
            }
            return respuesta;
        }
    }
}
