using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VentaController : Controller
    {
        private readonly IVenta _venta;
        private ControlError Log = new ControlError();

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
            catch (Exception ex)
            {
                Log.LogErrorMetodos("VentaController", "GetVenta", ex.Message);
            }
            return respuesta;
        }

        [HttpGet]
        [Route("GetVentaReporte")]
        public async Task<Respuesta> GetVentaReporte()
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.GetVentaReporte();
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

        [HttpPut]
        [Route("PutVenta")]
        public async Task<Respuesta> PutVenta([FromBody] Venta venta)
        {
            var respuesta = new Respuesta();
            try
            {
                respuesta = await _venta.PutVenta(venta);
            }
            catch (Exception)
            {

                throw;
            }
            return respuesta;
        }


    }
}
