using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeguimientosDeGraduados.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    [Required(ErrorMessage = "Debe ingresar un nombre.")]
    public string NombreDepartamento { get; set; } = string.Empty;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
