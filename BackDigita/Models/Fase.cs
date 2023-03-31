using System;
using System.Collections.Generic;

namespace BackDigita.Models;

public partial class Fase
{
    public int Id { get; set; }

    public int? IdProcessoSeletivo { get; set; }

    public bool? Tipo { get; set; }

    public string? Descrição { get; set; }

    public string? Local { get; set; }

    public virtual ProcessoSeletivo? IdProcessoSeletivoNavigation { get; set; }
}
