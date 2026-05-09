using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? EmailUsuario { get; set; }

    public string? PasswordHash { get; set; }

    public bool? EstadoCuenta { get; set; }

    public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
