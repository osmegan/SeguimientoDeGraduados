using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class ConveniosInstitucionale
{
    public int IdConvenio { get; set; }

    public int IdEmpresa { get; set; }

    public string TipoConvenio { get; set; } = null!;

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public bool EstadoConvenio { get; set; }

    public virtual CatEmpresa IdEmpresaNavigation { get; set; } = null!;
}
