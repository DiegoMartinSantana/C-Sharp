using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Nivele
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
