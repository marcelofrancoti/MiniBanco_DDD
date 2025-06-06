using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.TipoEmpresa.Request;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

[ApiController]
[Route("api/v1/enumeracao/empresa")]
public class TipoEmpresaController : BaseController
{
    private readonly IMediator _mediator;

    public TipoEmpresaController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("tipo")]
    public async Task<IActionResult> GetEmpresaById()
    {
        var request = new ListTiposEmpresaRequest();

        return await RequestService<ListTiposEmpresaRequest, List<TipoEmpresaDto>>(
            request,
            result => result.Success ? Ok(new { empresa = result.Data }) : NotFound(result.Message),
            message => BadRequest(message)
        );
    }
}
