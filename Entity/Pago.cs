using System;
using System.Collections.Generic;

namespace Entity;

public partial class Pago
{
    public long Id { get; set; }

    public long Idinscripcion { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal Importe { get; set; }

    public virtual Inscripcione IdinscripcionNavigation { get; set; } = null!;
}
