using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int IdDepartamentoFk { get; set; }

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual Departamento IdDepartamentoFkNavigation { get; set; } = null!;
}
