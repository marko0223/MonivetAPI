using System;
using System.Collections.Generic;

namespace MonivetAPI.Models;

public partial class TbProducto
{
    public string CodPro { get; set; } = null!;

    public string DesPro { get; set; } = null!;

    public decimal PrePro { get; set; }

    public int StkAct { get; set; }

    public int StkMin { get; set; }

    public string UniMed { get; set; } = null!;

    public string LinPro { get; set; } = null!;

    public string Importado { get; set; } = null!;
}
