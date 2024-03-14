﻿using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4;
using System.ComponentModel.DataAnnotations;

public partial class VistaVeloFinal
{
    [Key]
    public int IdCompe { get; set; }

    public int? Puesto { get; set; }

    public string Deportista { get; set; } = null!;

    public string? ResultadoClasificacion { get; set; }

    public string? ResultadoOctavos { get; set; }

    public string? ResultadoCuartos { get; set; }

    public string? ResultadoSemifinal { get; set; }

    public string? ResultadoFinal { get; set; }
}
