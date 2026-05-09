using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatFormasCulminacion
{
    public int IdForma { get; set; }

    public string NombreMetodo { get; set; } = null!;

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();
}
