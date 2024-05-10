using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Localidade
{
    public int Id { get; set; }

    public short Idpais { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<DatosPersonale> DatosPersonales { get; set; } = new List<DatosPersonale>();

    public virtual Paise IdpaisNavigation { get; set; } = null!;
}
