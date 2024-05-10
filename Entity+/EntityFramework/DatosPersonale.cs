using System;
using System.Collections.Generic;

namespace EntityFramework;

public partial class DatosPersonale
{
    public long Id { get; set; }

    public string Apellidos { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public DateOnly Nacimiento { get; set; }

    public string? Genero { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public string Domicilio { get; set; } = null!;

    public int Idlocalidad { get; set; }

    public virtual Usuario IdNavigation { get; set; } = null!;

    public virtual Localidade IdlocalidadNavigation { get; set; } = null!;
}
