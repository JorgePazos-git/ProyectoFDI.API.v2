using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.Models;

public partial class DeportistaModalidad
{
    public int IdDepmod { get; set; }

    public int? IdMod { get; set; }

    public int? IdDep { get; set; }

    public virtual Deportistum? IdDepNavigation { get; set; }

    public virtual Modalidad? IdModNavigation { get; set; }
}
