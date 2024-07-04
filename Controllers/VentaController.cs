using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;

        public VentaController(IVenta venta) 
        {
            this._venta = venta;
        }

        [HttpGet]
        [Route("GetVenta")]
        public async Task<Respuesta> GetVenta(string? numFactura)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVenta(numFactura);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }

        [HttpPost]
        [Route("PosVenta")]
        public async Task<Respuesta> PosVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PosVenta(venta);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }
    }
}
