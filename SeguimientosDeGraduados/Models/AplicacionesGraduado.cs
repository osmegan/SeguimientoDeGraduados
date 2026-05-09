using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class AplicacionesGraduado
{
    public int IdAplicacion { get; set; }

    public int? IdGraduado { get; set; }

    public int? IdOferta { get; set; }

    public DateOnly? FechaAplicacion { get; set; }

    public bool? FueContratado { get; set; }

    public virtual Graduado? IdGraduadoNavigation { get; set; }

    public virtual OfertasLaborale? IdOfertaNavigation { get; set; }
}
