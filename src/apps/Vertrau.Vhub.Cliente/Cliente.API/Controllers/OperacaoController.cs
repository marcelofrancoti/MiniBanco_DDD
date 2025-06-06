using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Operacao.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacaoController : BaseController
    {
        public OperacaoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListOperacao()
        {
            return await RequestService<OperacaoListarRequest, Paginacao<List<OperacaoDto>>>(
                new OperacaoListarRequest(),
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpPost]
        public async Task<IActionResult> InsertOperacao([FromBody] OperacaoInserirRequest operacaoRequest)
        {
            return await RequestService<OperacaoInserirRequest, long>(
                operacaoRequest,
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpPut]
        public async Task<IActionResult> AlterOperacao([FromBody] OperacaoAlterarRequest operacaoRequest)
        {
            return await RequestService<OperacaoAlterarRequest, long>(
                operacaoRequest,
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOperacao([FromHeader] int IdOperacao)
        {
            return await RequestService<OperacaoExcluirRequest, int>(
                new OperacaoExcluirRequest() { IdOperacao = IdOperacao },
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }
    }
}
