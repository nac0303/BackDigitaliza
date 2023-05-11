using System;
using System.Collections.Generic;
using Entity;
namespace BackDigita.Models;

public partial class Candidato
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataNascimento { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string? Curriculo { get; set; }

    public string? Login { get; set; }

    public string? Senha { get; set; }

    public bool? Ativo { get; set; }

    public static Candidato convertEntityToModel(ECandidato candidato)
    {
        return new Candidato()
        {
            Id = candidato.Id,
            Nome = candidato.Nome,
            DataNascimento = candidato.DataNascimento,
            Curriculo = candidato.Curriculo,
            Email = candidato.Email,
            Telefone = candidato.Telefone,
            Login = candidato.login,
            Senha = candidato.Senha,
            Ativo = candidato.Ativo
        };
    }
    
    public int save()
    {
        int id;

        using (var context = new ProcessoSeletivoContext())
        {

            var candidato = new Candidato
            {
                Nome = this.Nome,
                Email = this.Email,
                DataNascimento = this.DataNascimento,
                Telefone = this.Telefone,
                Login = this.Login,
                Senha = this.Senha,
                Curriculo = this.Curriculo
            };
        
            context.Candidatos.Add(candidato);
            context.SaveChanges();


            id = candidato.Id;
        }
        
        return id;
      
    }
}
