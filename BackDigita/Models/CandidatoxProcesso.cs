using System;
using System.Collections.Generic;

namespace BackDigita.Models;

public partial class CandidatoxProcesso
{
    public int Id { get; set; }

    public int IdCandidato { get; set; }

    public int IdProcesso { get; set; }

    public int IdFase { get; set; }

    public virtual Candidato IdCandidatoNavigation { get; set; } = null!;

    public virtual Fase IdFaseNavigation { get; set; } = null!;

    public virtual ProcessoSeletivo IdProcessoNavigation { get; set; } = null!;
}
