using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ForwarderController : ControllerBase
{
    private readonly IForwarderService _forwarders;
    private readonly IForwarderAuthService _forwardersAuth;
    public ForwarderController(IForwarderService forwarders,IForwarderAuthService forwardersAuth)
    {
        _forwarders = forwarders;
        _forwardersAuth = forwardersAuth;
    }

    [HttpGet("forwarders")]
    [Authorize]
    
    public async Task<IEnumerable<Forwarder>>GetAll()
    {
        return await _forwarders.GetMultipleAsync();
    }


    [HttpPost("forwarders/login")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Login(string email, string password)
    {
        var token = await _forwardersAuth.Login(email,password);

        if(token == null || token == string.Empty){
             return Unauthorized();
        }
        
        return Ok(new {token}); 
    }

    [HttpPost("forwarders/register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register(string name,string surname,string email, string password)
    {
        var result = await _forwardersAuth.Register(name,surname,email,password);

        if(!result){
            return BadRequest();
        }

        return Ok(result);
    }
}