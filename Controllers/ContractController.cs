using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContractController : ControllerBase
{
    [HttpGet]
    public IActionResult GetContracts()
    {
        return Ok(new { Message = "List of contracts" });
    }

    [HttpPost]
    public IActionResult CreateContract([FromBody] object contract)
    {
        return Ok(new { Message = "Contract created", Data = contract });
    }
}
