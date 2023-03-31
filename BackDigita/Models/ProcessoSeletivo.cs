using System;
using System.Collections.Generic;

namespace BackDigita.Models;

public partial class ProcessoSeletivo
{
    public int Id { get; set; }

    public int IdAdm { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public bool? Ativo { get; set; }

    public int? QtdMax { get; set; }

    public virtual ICollection<Fase> Fases { get; } = new List<Fase>();

    public virtual Adm IdAdmNavigation { get; set; } = null!;
}
