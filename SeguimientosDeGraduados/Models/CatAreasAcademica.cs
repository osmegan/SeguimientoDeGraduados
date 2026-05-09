using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatAreasAcademica
{
    public int IdArea { get; set; }

    public string NombreArea { get; set; } = null!;

    public virtual ICollection<CatCarrera> CatCarreras { get; set; } = new List<CatCarrera>();
}
