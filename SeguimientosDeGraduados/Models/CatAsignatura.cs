using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class CatAsignatura
{
    public int IdAsignatura { get; set; }

    public string CodigoClase { get; set; } = null!;

    public string NombreClase { get; set; } = null!;

    public virtual ICollection<CatPensumCarreraAsignatura> CatPensumCarreraAsignaturas { get; set; } = new List<CatPensumCarreraAsignatura>();
}
