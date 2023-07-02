using System;
using System.Collections.Generic;

namespace MonivetAPI.Models;

public partial class TbDetalleVentum
{
    public int NumVen { get; set; }

    public string DesVen { get; set; } = null!;

    public int CanVen { get; set; }

    public decimal PreVen { get; set; }

    public decimal TotalVen { get; set; }
}
