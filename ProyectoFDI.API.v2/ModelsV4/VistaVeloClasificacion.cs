using System;
using System.Collections.Generic;

namespace ProyectoFDI.API.v2.ModelsV4;
using System.ComponentModel.DataAnnotations;

public partial class VistaVeloClasificacion
{
    [Key]
    public int IdCompe { get; set; }

    public int? Puesto { get; set; }

    public string? ResultadoClasificacion { get; set; }

    public string Deportista { get; set; } = null!;
}
