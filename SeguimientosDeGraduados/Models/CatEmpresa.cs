using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatEmpresa
{
    public int IdEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? ContactoNombre { get; set; }

    public string? ContactoCargo { get; set; }

    public int? IdDireccion { get; set; }

    public int? IdCorreoElectronicoFk { get; set; }

    public int? IdTelefonoFk { get; set; }

    public virtual ICollection<ConveniosInstitucionale> ConveniosInstitucionales { get; set; } = new List<ConveniosInstitucionale>();

    public virtual CorreosElectronico? IdCorreoElectronicoFkNavigation { get; set; }

    public virtual Direccione? IdDireccionNavigation { get; set; }

    public virtual ContactosTelefonico? IdTelefonoFkNavigation { get; set; }

    public virtual ICollection<OfertasLaborale> OfertasLaborales { get; set; } = new List<OfertasLaborale>();
}
