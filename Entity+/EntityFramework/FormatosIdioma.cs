using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class FormatosIdioma
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<IdiomasXCurso> IdiomasXCursos { get; set; } = new List<IdiomasXCurso>();
}
