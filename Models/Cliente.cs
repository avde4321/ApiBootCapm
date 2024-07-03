﻿using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? ClienteNombre { get; set; }

    public double? Cedula { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
