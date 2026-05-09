using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CorreosElectronico
{
    public int IdCorreoElectronico { get; set; }

    public string? CorreoPersonal { get; set; }

    public string? CorreoInstitucional { get; set; }

    public virtual ICollection<CatEmpresa> CatEmpresas { get; set; } = new List<CatEmpresa>();

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();
}
