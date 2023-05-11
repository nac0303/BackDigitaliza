using Microsoft.AspNetCore.Mvc;
using BackDigita.Models;
using Entity;
namespace BackDigita.Controllers;


[ApiController]
[Route("[controller]")]
public class ProcessoSeletivoController : ControllerBase
{
    private readonly ProcessoSeletivoContext DBContext;

    public ProcessoSeletivoController(ProcessoSeletivoContext dBContext)
    {
        this.DBContext = dBContext;
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var Adm = this.DBContext.ProcessoSeletivos.ToList();
        return Ok(Adm);
    }

    [HttpGet("Update")]
    public async Task<IActionResult> Update()
    {
        var candidatos = this.DBContext.ProcessoSeletivos.ToList();
        return Ok(candidatos);
    }


    

    [HttpPost]
    [Route("register")]
    public int registerClient([FromBody] ProcessoSeletivo processo)
    {
        var id = processo.save(3);

        return 1;
    }
}
