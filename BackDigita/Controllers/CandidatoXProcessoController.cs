using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;
using Entity;
namespace BackDigita.Controllers;


[ApiController]
[Route("[controller]")]
public class CandidatoxProcessoController : ControllerBase
{
    private readonly ProcessoSeletivoContext DBContext;

      public CandidatoxProcessoController(ProcessoSeletivoContext dBContext)
    {
        this.DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var candidatoxes = this.DBContext.CandidatoxProcessos.ToList();
        return Ok(candidatoxes);
    }

    [HttpGet("GetWithInfo/{IdCandidato}")]
    public async Task<IActionResult> GetWithInfo(int IdCandidato)
    {
        var faseCandidato = Models.CandidatoxProcesso.getFaseAtualCandidato(IdCandidato);
        return Ok(faseCandidato);
    }

    [HttpGet("Update")]
    public async Task<IActionResult> Update()
    {
        var candidatos = this.DBContext.CandidatoxProcessos.ToList();
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

    [HttpGet("GetAllCandidatoProcesso/{id}")]
    public async Task<IActionResult> GetAllCandidatoProcesso(int id)
    {
       using (var context = new ProcessoSeletivoContext()){
         var candidatoProcesso = (from cp in context.CandidatoxProcessos join c in context.Candidatos on cp.IdCandidato equals c.Id select new {
            Nome = c.Nome,
            IdProceso = cp.IdProcesso
          }).Where(n => n.IdProceso == id).ToList();
            
         return Ok(candidatoProcesso);
      }
    }
}
