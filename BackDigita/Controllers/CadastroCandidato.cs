using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;

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
}
