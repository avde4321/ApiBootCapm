using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Venta
{
    public int IdFactura { get; set; }

    public string? NumFact { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? ClienteId { get; set; }

    public int? ProductoId { get; set; }

    public int? ModeloId { get; set; }

    public int? CategId { get; set; }

    public int? MarcaId { get; set; }

    public int? SucursalId { get; set; }

    public string? Caja { get; set; }

    public string? Vendedor { get; set; }

    public double? Precio { get; set; }

    public double? Unidades { get; set; }

    public string? Estado { get; set; }

    public virtual Categorium? Categ { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual Modelo? Modelo { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Sucursal? Sucursal { get; set; }
}
