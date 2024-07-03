using EjemploEntity.Interfaces;
using EjemploEntity.Models;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Services
{
    public class CLienteServices : ICliente
    {
        private readonly MasterclassContext _context;

        public CLienteServices(MasterclassContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> GetCliente(int clientId, string? nombrecliente, double identificacion)
        {
            var respuesta = new Respuesta();
            try
            {
                var query = _context.Clientes;


                if (clientId == 0 && nombrecliente == null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A")).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (clientId != 0 && nombrecliente == null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteId.Equals(clientId)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (clientId == 0 && nombrecliente != null && identificacion == 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteNombre.Equals(nombrecliente)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (clientId == 0 && nombrecliente == null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.Cedula.Equals(identificacion)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }
                else if (clientId != 0 && nombrecliente != null && identificacion != 0)
                {
                    respuesta.Cod = "000";
                    respuesta.Data = await query.Where(x => x.Estado.Equals("A") && x.ClienteId.Equals(clientId) && x.ClienteNombre.Equals(nombrecliente) && x.Cedula.Equals(identificacion)).ToListAsync();
                    respuesta.Mensaje = "OK";
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return respuesta;
        }
    }
}
