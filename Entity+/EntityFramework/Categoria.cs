using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Categoria
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Curso> Idcursos { get; set; } = new List<Curso>();
}
