using System;
using System.Collections.Generic;

namespace SeguimientosDeGraduados.Models;

public partial class ProveedoresTelefonico
{
    public int IdProveedorTelefonico { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ContactosTelefonico> ContactosTelefonicos { get; set; } = new List<ContactosTelefonico>();
}
