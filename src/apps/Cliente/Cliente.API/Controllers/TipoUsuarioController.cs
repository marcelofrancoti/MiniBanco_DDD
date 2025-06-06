using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.TipoUsuario;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

[ApiController]
[Route("api/v1/enumeracao")]
public class TipoUsuarioController : BaseController
{
    private readonly IMediator _mediator;

    public TipoUsuarioController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("administrador")]
    public async Task<IActionResult> GetTiposUsuario()
    {
        var request = new ListTiposUsuarioRequest();

        return await RequestService<ListTiposUsuarioRequest, List<TipoUsuarioDto>>(
            request,
            result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
            message => BadRequest(message)
        );
    }
}
