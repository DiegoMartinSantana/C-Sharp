using System;
using System.Collections.Generic;

namespace Entity;

public partial class Usuario
{
    public long Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public virtual DatosPersonale? DatosPersonale { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Curso> Idcursos { get; set; } = new List<Curso>();
}
