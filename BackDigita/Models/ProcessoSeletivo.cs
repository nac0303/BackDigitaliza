using System;
using System.Collections.Generic;

namespace BackDigita.Models;

public partial class ProcessoSeletivo
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public bool? Ativo { get; set; }

    public int? QtdMax { get; set; }

    public virtual ICollection<Fase> Fases { get; set;} = new List<Fase>();

    public virtual Adm adm { get; set; } = null!;

    public int save(int idAdm)
    {
        int id;

        
        using (var context = new ProcessoSeletivoContext())
        {
            var newAdm = context.Adms.FirstOrDefault(a => a.Id == idAdm);

            if (adm == null)
                return -2;

            var processo = new ProcessoSeletivo
            {
                Nome = this.Nome,
                DataInicio = this.DataInicio,
                DataFim = this.DataFim,
                Ativo = this.Ativo,
                QtdMax = this.QtdMax,
                adm = newAdm
            };
            context.ProcessoSeletivos.Add(processo);
            context.Entry(processo.adm).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();


            id = processo.Id;
        }
        
        return id;
      
    }   


}


