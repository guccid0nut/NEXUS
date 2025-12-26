using Microsoft.AspNetCore.Mvc;

namespace KONGOR.MasterServer.Controllers;

[ApiController]
[Route("master/questserver")]
[Route("questserver")]
public class QuestServerController : ControllerBase
{
    [HttpPost("getplayerquests")]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult GetPlayerQuests()
    {
        // Stub implementation to return 200 OK and prevent 404/500 errors
        return Ok();
    }
}
