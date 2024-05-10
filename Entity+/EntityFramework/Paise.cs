using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class Paise
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Localidade> Localidades { get; set; } = new List<Localidade>();
}
