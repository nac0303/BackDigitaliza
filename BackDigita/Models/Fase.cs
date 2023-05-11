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


    public static List<object> getByProcessoId(int id){
        
        List<object> fases = new List<object>();

        using var context = new ProcessoSeletivoContext();

        var fasesDB = context.Fases.Where(s => s.IdProcessoSeletivo == id).ToList();
        
        foreach (var fase in fasesDB){
            fases.Add(new{
                id = fase.Id,
                IdProcessoSeletivo = fase.IdProcessoSeletivo,
                Tipo = fase.Tipo,
                Descrição = fase.Descrição,
                Local = fase.Local,
            });
        }
        return fases;
    }

}
