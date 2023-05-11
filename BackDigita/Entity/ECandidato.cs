namespace Entity;

public class ECandidato{
    public int Id {get;set;}
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string Curriculo { get; set; }
    public string login { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
}