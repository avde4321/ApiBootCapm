using EjemploEntity.DTOs;
using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EjemploEntity.Services
{
    public class VentaServcies : IVenta
    {
        private readonly MasterclassContext _context;
        private ControlError Log = new ControlError();


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
                    respuesta.Data = await query.Where(x => x.Estado.Equals("Registrada")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception ex)
            {
                respuesta.Cod = "999";
                respuesta.Mensaje = $"Se presento una novedad, comunicarse con el departamentos de sistemas";
                Log.LogErrorMetodos("VentaServcies", "GetVenta", ex.Message);
            }
            return respuesta;
        }

        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta.Cod = "000";

                respuesta.Data = await _context.Ventas
                    .Where(v => v.Precio > 100)
                    .GroupBy(v => v.Precio)
                    .Select(g => new
                    {
                        CantidadRegistro = g.Count(),
                        ValorConsultado = g.Key
                    }).ToListAsync();

                respuesta.Mensaje = "OK";
            }
            catch (Exception ex)
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

        public async Task<Respuesta> PutVenta(Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                _context.Ventas.Update(venta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }
    }
}
