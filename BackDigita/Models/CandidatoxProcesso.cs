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

    public static object getFaseAtualCandidato(int IdCandidato){

        var context = new ProcessoSeletivoContext();

        var faseCandidatoProcesso = (from cp in context.CandidatoxProcessos join f in context.Fases on cp.IdFase equals f.Id 
          join p in context.ProcessoSeletivos on cp.IdProcesso equals p.Id
          join c in context.Candidatos on cp.IdCandidato equals c.Id where cp.IdCandidato == IdCandidato orderby cp.IdFase descending select new {
            Nome = c.Nome,
            Id = c.Id,
            DataNascimento = c.DataNascimento,
            Email = c.Email,
            NomeProcesso = p.Nome,
            Curriculo = c.Curriculo,
            processo = p.Nome,
          }).FirstOrDefault();

        return faseCandidatoProcesso;
    }

    public int Save(int id){

        using (var context = new ProcessoSeletivoContext())
        {
            
        }
        
        return id;
      
    }

    // public static List<CandidatoxProcesso> GetCandidatosProcesso(int id){
      
    // }

}
