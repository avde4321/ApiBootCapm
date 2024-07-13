﻿using EjemploEntity.Models;
using EjemploEntity.Utilitrios;
using Microsoft.AspNetCore.Mvc;

namespace EjemploEntity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtrasController : Controller
    {
        private ControlError log = new ControlError();
        private PokeApi pokeApi = new PokeApi();
        private readonly IConfiguration _configuration;

        public ExtrasController(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }

        [HttpGet]
        [Route("GetPokeApi")]
        public async Task<Respuesta> GetPokeApi()
        {
            var respuesta = new Respuesta();
            try
            {
                var url = _configuration.GetSection("Keys:UrlPokeApi").Value!;

                respuesta = await pokeApi.GetPokeApi(url);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos("ExtrasController", "GetPokeApi", ex.Message);
            }
            return respuesta;
        }
    }
}
