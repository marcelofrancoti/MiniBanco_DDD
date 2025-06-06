using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    [HttpGet("token-info")]
    public IActionResult GetTokenInfo()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

        var usuarioId = jsonToken.Claims.ToList()[24].Value;

        return Ok(new
        {
            Header = jsonToken.Header,
            Payload = jsonToken.Payload,
        });
    }
}
