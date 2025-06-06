using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controller
{
    [ApiController]
    [Route("api/v1/cessionarios")]
    public class CessionarioController : BaseController
    {
        public CessionarioController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> ListCessionarios([FromQuery] CessionarioListarRequest request)
        {
            return await RequestService<CessionarioListarRequest, Paginacao<List<ListCessionarioDto>>>(
                request,
                result => result.Success ? Ok(result) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ListCessionariosPorId( long Id)
        {
            var request = new CessionarioListarPorIdRequest(Id);
            return await RequestService<CessionarioListarPorIdRequest, Paginacao<List<ListarCessionarioDto>>>(
                request,
                result => result.Success ? Ok(result) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpPost]
        public async Task<IActionResult> InsertCessionario([FromBody] CessionarioInserirRequest cessionarioRequest)
        {
            return await RequestService<CessionarioInserirRequest, long>(
                cessionarioRequest,
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpPut]
        public async Task<IActionResult> AlterCessionario([FromBody] CessionarioAlterarRequest cessionarioRequest)
        {
            return await RequestService<CessionarioAlterarRequest, long>(
                cessionarioRequest,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCessionario([FromHeader] long IdCessionario)
        {
            return await RequestService<CessionarioExcluirRequest, long>(
                new CessionarioExcluirRequest { IdCessionario = IdCessionario },
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }
    }
}
