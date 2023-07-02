using System;
using System.Collections.Generic;

namespace MonivetAPI.Models;

public partial class TbLogin
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contra { get; set; } = null!;
}
