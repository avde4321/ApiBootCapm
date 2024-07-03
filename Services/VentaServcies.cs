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

                
                if (numFactura != null && numFactura != "0")
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            where v.NumFact.Equals(numFactura) && v.Estado.Equals("Registrada")
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
                                            }).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await (from v in _context.Ventas
                                            join cl in _context.Clientes on v.ClienteId equals cl.ClienteId
                                            join pr in _context.Productos on v.ProductoId equals pr.ProductoId
                                            join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                            join ct in _context.Categoria on v.CategId equals ct.CategId
                                            join sc in _context.Sucursals on v.SucursalId equals sc.SucursalId
                                            where v.Estado.Equals("Registrada")
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
                                            }).ToListAsync(); ;
                    respuesta.Mensaje = "OK";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
