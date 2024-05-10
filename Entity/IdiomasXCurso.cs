using System;
using System.Collections.Generic;

namespace Entity;

public partial class IdiomasXCurso
{
    public long Idcurso { get; set; }

    public short Ididioma { get; set; }

    public byte IdformatoIdioma { get; set; }

    public virtual Curso IdcursoNavigation { get; set; } = null!;

    public virtual FormatosIdioma IdformatoIdiomaNavigation { get; set; } = null!;

    public virtual Idioma IdidiomaNavigation { get; set; } = null!;
}
