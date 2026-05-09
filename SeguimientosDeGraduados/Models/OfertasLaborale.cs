using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class OfertasLaborale
{
    public int IdOferta { get; set; }

    public int? IdEmpresa { get; set; }

    public string? PuestoOfrecido { get; set; }

    public int? IdCarreraRequerida { get; set; }

    public bool? OfertaActiva { get; set; }

    public virtual ICollection<AplicacionesGraduado> AplicacionesGraduados { get; set; } = new List<AplicacionesGraduado>();

    public virtual CatEmpresa? IdEmpresaNavigation { get; set; }
}
