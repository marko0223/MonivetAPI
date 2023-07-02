using System;
using System.Collections.Generic;

namespace MonivetAPI.Models;

public partial class TbDistrito
{
    public string CodDis { get; set; } = null!;

    public string? NomDis { get; set; }

    public virtual ICollection<TbCliente> TbClientes { get; set; } = new List<TbCliente>();
}
