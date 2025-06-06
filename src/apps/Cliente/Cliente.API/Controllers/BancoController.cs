using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Banco.Request;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

[ApiController]
[Route("api/v1/enumeracao")]
public class BancoController : BaseController
{
    private readonly IMediator _mediator;

    public BancoController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("banco")]
    public async Task<IActionResult> GetBancos()
    {
        var request = new ListBancosRequest();

        return await RequestService<ListBancosRequest, List<BancoDto>>(
            request,
            result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
            message => BadRequest(message)
        );
    }
}
