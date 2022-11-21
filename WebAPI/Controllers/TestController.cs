using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class TestController : ControllerBase
{
    [HttpGet("authorized"), Authorize]
    public ActionResult GetAsAuthorized()
    {
        return Ok("This was accepted as authorized");
    }
    [HttpGet("allowanon"), AllowAnonymous]
    public ActionResult GetAsAnon()
    {
        return Ok("This was accepted as anonymous");
    }

    [HttpGet("securitylevel"), Authorize("SecurityLevel4")]
    public ActionResult GetAsSecurityLevel()
    {
        return Ok("Accepted as security level");
    }
}