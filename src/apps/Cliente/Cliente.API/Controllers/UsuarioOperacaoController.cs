using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.UsuarioOperacao;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioOperacaoController : BaseController
    {
        public UsuarioOperacaoController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListUsuarioOperacao()
        {
            return await RequestService<UsuarioOperacaoListarRequest, List<UsuarioOperacaoDto>>(
             new UsuarioOperacaoListarRequest(),
             result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuarioOperacao([FromBody] UsuarioOperacaoInserirRequest request)
        {
            return await RequestService<UsuarioOperacaoInserirRequest, int>(
             request,
             result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }

        [HttpPut]
        public async Task<IActionResult> AlterUsuarioOperacao([FromBody] UsuarioOperacaoAlterarRequest request)
        {
            return await RequestService<UsuarioOperacaoAlterarRequest, int>(
             request,
             result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuarioOperacao([FromHeader] int idUsuarioOperacao)
        {
            return await RequestService<UsuarioOperacaoExcluirRequest, int>(
             new UsuarioOperacaoExcluirRequest() { IdUsuarioOperacao = idUsuarioOperacao },
             result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }
    }
}
