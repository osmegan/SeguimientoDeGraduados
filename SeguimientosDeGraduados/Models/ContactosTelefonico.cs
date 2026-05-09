using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class ContactosTelefonico
{
    public int IdTelefono { get; set; }

    public string? TelefonoMovil { get; set; }

    public string? TelefonoConvencional { get; set; }

    public int IdProveedorTelefonoFk { get; set; }

    public virtual ICollection<CatEmpresa> CatEmpresas { get; set; } = new List<CatEmpresa>();

    public virtual ICollection<Graduado> Graduados { get; set; } = new List<Graduado>();

    public virtual ProveedoresTelefonico IdProveedorTelefonoFkNavigation { get; set; } = null!;
}
