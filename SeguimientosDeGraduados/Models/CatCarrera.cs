using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatCarrera
{
    public int IdCarrera { get; set; }

    public int IdAreaFk { get; set; }

    public string NombreCarrera { get; set; } = null!;

    public virtual ICollection<CatPensumCarreraAsignatura> CatPensumCarreraAsignaturas { get; set; } = new List<CatPensumCarreraAsignatura>();

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();

    public virtual CatAreasAcademica IdAreaFkNavigation { get; set; } = null!;
}
