using System;
using System.Collections.Generic;

namespace BackDigita.Models;

public partial class Adm
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataDeNascimento { get; set; }

    public string? Edv { get; set; }

    public string? Senha { get; set; }

    public bool? Ativo { get; set; }

    public virtual ICollection<ProcessoSeletivo> ProcessoSeletivos { get; } = new List<ProcessoSeletivo>();
}
