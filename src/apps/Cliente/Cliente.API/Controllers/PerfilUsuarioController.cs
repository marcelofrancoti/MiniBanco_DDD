using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.PerfilUsuario.Request;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

[ApiController]
[Route("api/v1/enumeracao/usuario")]
public class PerfilUsuarioController : BaseController
{
    private readonly IMediator _mediator;

    public PerfilUsuarioController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("perfil")]
    public async Task<IActionResult> GetPerfisUsuario()
    {
        var request = new ListPerfisUsuarioRequest();

        return await RequestService<ListPerfisUsuarioRequest, List<PerfilUsuarioDto>>(
            request,
            result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
            message => BadRequest(message)
        );
    }
}
