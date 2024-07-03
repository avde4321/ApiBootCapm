using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : Controller
    {
        public readonly ICliente _cliente;

        public ClienteController(ICliente cliente) 
        {
            this._cliente = cliente;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(int clientId, string? nombrecliente, double identificacion)
        {
            var respeusta = new Respuesta();
            try
            {
                respeusta = await _cliente.GetCliente(clientId, nombrecliente, identificacion);
            }
            catch (Exception ex)
            {

                throw;
            }
            return respeusta;
        }
    }
}
