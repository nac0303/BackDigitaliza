using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;
using Entity;
namespace BackDigita.Controllers;

[ApiController]
[Route("[controller]")]
public class FaseController : ControllerBase
{

    private readonly ProcessoSeletivoContext DBContext;

    public FaseController(ProcessoSeletivoContext dBContext)
    {
        this.DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var candidatos = this.DBContext.Fases.ToList();
        return Ok(candidatos);
    }

    [HttpGet("GetByCandidatoId/{id}")]
    public async Task<IActionResult> GetByProcessoId(int id)
    {
        var FaseProcesso = Models.Fase.getByProcessoId(id);

         return Ok(FaseProcesso);
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
        var id = newCandidato.save();

        return 1;
    }

}
