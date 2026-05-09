using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatPensumCarreraAsignatura
{
    public int IdCarreraFk { get; set; }

    public int IdAsignaturaFk { get; set; }

    public int? AnioAsignado { get; set; }

    public virtual CatAsignatura IdAsignaturaFkNavigation { get; set; } = null!;

    public virtual CatCarrera IdCarreraFkNavigation { get; set; } = null!;
}
