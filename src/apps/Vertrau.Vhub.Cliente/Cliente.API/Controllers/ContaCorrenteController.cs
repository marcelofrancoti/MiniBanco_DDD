

using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : BaseController
    {
        public ContaCorrenteController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> InsertContaCorrente([FromBody] ContaCorrenteInserirRequest contaCorrenteRequest)
        {
            return await RequestService<ContaCorrenteInserirRequest, long>(
                contaCorrenteRequest,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }



        [HttpPut]
        public async Task<IActionResult> AlterContaCorrente([FromBody] ContaCorrenteAlterarRequest contaCorrenteRequest)
        {
            return await RequestService<ContaCorrenteAlterarRequest, long>(
                contaCorrenteRequest,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContaCorrente([FromHeader] long IdContaCorrente)
        {
            return await RequestService<ContaCorrenteExcluirRequest, long>(
                new ContaCorrenteExcluirRequest() { IdContaCorrente = IdContaCorrente },
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet]
        public async Task<IActionResult> ListContaCorrentes([FromQuery] ContaCorrenteListarRequest request)
        {
            return await RequestService<ContaCorrenteListarRequest, Paginacao<List<ListarContaCorrenteDto>>>(
                request,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ListContaCorrentes(long Id)
        {
            var request = new ContaCorrenteGetIdRequest(Id);
            return await RequestService<ContaCorrenteGetIdRequest, List<ContaCorrenteDto>>(
                request,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet("conta-corrente")]
        public async Task<IActionResult> GetContasCorrentes()
        {
            var request = new ListContasCorrentesRequest();

            return await RequestService<ListContasCorrentesRequest, List<ContaCorrenteEnumDto>>(
                request,
                result => result.Success ? Ok(new { itens = result.Data }) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }
    }
}
