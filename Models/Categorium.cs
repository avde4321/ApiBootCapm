﻿using System;
using System.Collections.Generic;

namespace EjemploEntity.Models;

public partial class Categorium
{
    public int CategId { get; set; }

    public string? CategNombre { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
