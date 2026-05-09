using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class Direccione
{
    public int IdDireccion { get; set; }

    public string? DetalleDireccion { get; set; }

    public int IdMunicipioFk { get; set; }

    public virtual ICollection<CatEmpresa> CatEmpresas { get; set; } = new List<CatEmpresa>();

    public virtual ICollection<CatSedesCur> CatSedesCurs { get; set; } = new List<CatSedesCur>();

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();

    public virtual Municipio IdMunicipioFkNavigation { get; set; } = null!;
}
