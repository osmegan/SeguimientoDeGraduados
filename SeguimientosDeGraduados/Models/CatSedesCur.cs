using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatSedesCur
{
    public int IdSede { get; set; }

    public string NombreSede { get; set; } = null!;

    public int? IdDireccionFk { get; set; }

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();

    public virtual Direccione? IdDireccionFkNavigation { get; set; }
}
