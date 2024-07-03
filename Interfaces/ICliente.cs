using EjemploEntity.Models;

namespace EjemploEntity.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(int clientId, string? nombrecliente, double identificacion);
    }
}
