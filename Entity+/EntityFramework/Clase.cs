using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Clase
{
    public long Id { get; set; }

    public long Idcurso { get; set; }

    public string Nombre { get; set; } = null!;

    public short? Numero { get; set; }

    public int Duracion { get; set; }

    public virtual ICollection<Contenido> Contenidos { get; set; } = new List<Contenido>();

    public virtual Curso IdcursoNavigation { get; set; } = null!;
}
