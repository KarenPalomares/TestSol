using System;
using System.Collections.Generic;

namespace Datos;

public partial class Area
{
    public int IdArea { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
