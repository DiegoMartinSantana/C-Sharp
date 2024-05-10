using System;
using System.Collections.Generic;

namespace Entity;

public partial class Inscripcione
{
    public long Id { get; set; }

    public long Idusuario { get; set; }

    public long Idcurso { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Costo { get; set; }

    public virtual Certificacione? Certificacione { get; set; }

    public virtual Curso IdcursoNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual Reseña? Reseña { get; set; }
}
