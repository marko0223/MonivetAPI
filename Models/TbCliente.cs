using System;
using System.Collections.Generic;

namespace MonivetAPI.Models;

public partial class TbCliente
{
    public string CodCli { get; set; } = null!;

    public string NomCli { get; set; } = null!;

    public string DirCli { get; set; } = null!;

    public string TlfCli { get; set; } = null!;

    public string? DniCli { get; set; }

    public string CodDis { get; set; } = null!;

    public DateTime FecReg { get; set; }

    public string TipCli { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public virtual TbDistrito CodDisNavigation { get; set; } = null!;
}
