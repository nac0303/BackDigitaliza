using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;
using Entity;
namespace BackDigita.Controllers;

[ApiController]
[Route("[controller]")]
public class AdmController : ControllerBase
{

    private readonly ProcessoSeletivoContext DBContext;

    public AdmController(ProcessoSeletivoContext dBContext)
    {
        this.DBContext = dBContext;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var adm = this.DBContext.Adms.ToList();
        return Ok(adm);
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
