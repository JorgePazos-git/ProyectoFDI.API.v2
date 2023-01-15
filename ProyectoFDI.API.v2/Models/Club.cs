using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.Models;

public partial class Club
{
    public int IdClub { get; set; }

    public string? NombreClub { get; set; }

    public virtual ICollection<Deportistum> Deportista { get; } = new List<Deportistum>();
}
