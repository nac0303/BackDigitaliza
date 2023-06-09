using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;
using Entity;
namespace BackDigita.Controllers;

[ApiController]
[Route("[controller]")]
public class CadastroCandidato : ControllerBase
{

    private readonly ProcessoSeletivoContext DBContext;

    public CadastroCandidato(ProcessoSeletivoContext dBContext)
    {
        this.DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var candidatos = this.DBContext.Candidatos.ToList();
        return Ok(candidatos);
    }

    [HttpGet("GetCandiato/{id}")]
    public async Task<IActionResult> GetCandidato(int id)
    {
        var candidato = this.DBContext.Candidatos.Where(c => c.Id == id);
        return Ok(candidato);
    }

    [HttpGet("Update")]
    public async Task<IActionResult> Update()
    {
        var candidatos = this.DBContext.Candidatos.ToList();
        return Ok(candidatos);
    }

    [HttpPost]
    [Route("register")]
    public int registerClient([FromBody] ECandidato candidato)
    {
        var newCandidato = Candidato.convertEntityToModel(candidato);
        Console.WriteLine(candidato.Nome);
        var id = newCandidato.save();

        return 1;
    }

}
