using System;
using System.Collections.Generic;

namespace Entity;

public partial class Curso
{
    public long Id { get; set; }

    public byte? Idnivel { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal CostoCurso { get; set; }

    public decimal CostoCertificacion { get; set; }

    public DateOnly Estreno { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

    public virtual ICollection<IdiomasXCurso> IdiomasXCursos { get; set; } = new List<IdiomasXCurso>();

    public virtual Nivele? IdnivelNavigation { get; set; }

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Categoria> Idcategoria { get; set; } = new List<Categoria>();

    public virtual ICollection<Usuario> Idusuarios { get; set; } = new List<Usuario>();
}
