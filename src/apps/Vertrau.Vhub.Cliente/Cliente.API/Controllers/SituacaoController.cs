using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Situacao.Request;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

[ApiController]
[Route("api/v1/enumeracao/generico")]
public class SituacaoController : BaseController
{
    private readonly IMediator _mediator;

    public SituacaoController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("situacao")]
    public async Task<IActionResult> GetSituacoes()
    {
        var request = new ListSituacoesRequest();

        return await RequestService<ListSituacoesRequest, List<SituacaoDto>>(
            request,
            result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
            message => BadRequest(message)
        );
    }
}
