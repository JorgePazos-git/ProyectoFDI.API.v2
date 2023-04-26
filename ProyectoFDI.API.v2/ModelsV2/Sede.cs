﻿using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV2;

public partial class Sede
{
    public int IdSede { get; set; }

    public string? NombreSede { get; set; }

    public virtual ICollection<Competencium> Competencia { get; } = new List<Competencium>();
}
