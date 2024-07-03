using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? ProductoDescrip { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public double? Precio { get; set; }

    public int? CategId { get; set; }

    public int? MarcaId { get; set; }

    public int? ModeloId { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
