using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class Graduado
{
    public int IdGraduado { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string? Genero { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Nacionalidad { get; set; }

    public string? CedulaOPasaporte { get; set; }

    public bool? EsExtranjero { get; set; }

    public int? IdSedeIngreso { get; set; }

    public DateOnly? FechaEgreso { get; set; }

    public DateOnly? FechaTitulacion { get; set; }

    public string? EstadoAcademico { get; set; }

    public int? IdCorreoElectronicoFk { get; set; }

    public int? IdTelefonoFk { get; set; }

    public int? IdDireccionFk { get; set; }

    public int? IdFormaFk { get; set; }

    public string? RutaCartaEgreso { get; set; }

    public int? IdCarreraFk { get; set; }

    public virtual ICollection<AplicacionesGraduado> AplicacionesGraduados { get; set; } = new List<AplicacionesGraduado>();

    public virtual CatCarrera? IdCarreraFkNavigation { get; set; }

    public virtual CorreosElectronico? IdCorreoElectronicoFkNavigation { get; set; }

    public virtual Direccione? IdDireccionFkNavigation { get; set; }

    public virtual CatFormasCulminacion? IdFormaFkNavigation { get; set; }

    public virtual CatSedesCur? IdSedeIngresoNavigation { get; set; }

    public virtual ContactosTelefonico? IdTelefonoFkNavigation { get; set; }

    public virtual ICollection<SituacionLaboral> SituacionLaborals { get; set; } = new List<SituacionLaboral>();
}
