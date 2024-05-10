using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Certificacione
{
    public long Idinscripcion { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Costo { get; set; }

    public virtual Inscripcione IdinscripcionNavigation { get; set; } = null!;
}
