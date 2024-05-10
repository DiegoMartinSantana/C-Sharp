using System;
using System.Collections.Generic;

namespace Entity;

public partial class Reseña
{
    public long Idinscripcion { get; set; }

    public DateOnly Fecha { get; set; }

    public string Observaciones { get; set; } = null!;

    public decimal Puntaje { get; set; }

    public bool Inapropiada { get; set; }

    public virtual Inscripcione IdinscripcionNavigation { get; set; } = null!;
}
