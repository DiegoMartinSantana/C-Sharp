using System;
using System.Collections.Generic;

namespace Entity;

public partial class Contenido
{
    public long Id { get; set; }

    public long Idclase { get; set; }

    public int Idtipo { get; set; }

    public int Tamaño { get; set; }

    public virtual Clase IdclaseNavigation { get; set; } = null!;

    public virtual TiposContenido IdtipoNavigation { get; set; } = null!;
}
