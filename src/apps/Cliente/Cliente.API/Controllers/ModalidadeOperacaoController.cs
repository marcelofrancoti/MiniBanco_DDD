using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.ModalidadeOperacao;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controllers
{
    [ApiController]
    [Route("api/v1/enumeracao")]
    public class ModalidadeOperacaoController : BaseController
    {
        public ModalidadeOperacaoController(IMediator mediator) : base(mediator) { }

        [HttpGet("modalidade-operacao")]
        public async Task<IActionResult> GetModalidadesOperacao()
        {
            var request = new ListModalidadesOperacaoRequest();

            return await RequestService<ListModalidadesOperacaoRequest, List<ModalidadeOperacaoDto>>(
                request,
                result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }
    }
}
