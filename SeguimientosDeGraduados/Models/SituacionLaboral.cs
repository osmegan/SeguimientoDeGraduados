using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class SituacionLaboral
{
    public int IdLaboral { get; set; }

    public int? IdGraduado { get; set; }

    public bool? EstaEmpleado { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Cargo { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public int? AfinidadCarrera { get; set; }

    public virtual Graduado? IdGraduadoNavigation { get; set; }
}
