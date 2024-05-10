using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class TiposContenido
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Contenido> Contenidos { get; set; } = new List<Contenido>();
}
