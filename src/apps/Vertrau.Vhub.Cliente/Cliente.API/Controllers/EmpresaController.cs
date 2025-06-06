using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Empresa.Request;
using  Cliente.Aplication.Requisicoes;
using  Cliente.Contracts.Dto;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : BaseController
    {
        public EmpresaController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpresa([FromBody] EmpresaInserirRequest empresaRequest)
        {
            return await RequestService<EmpresaInserirRequest, long>(
             empresaRequest,
             result => result.Success ? Ok(result) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }

        [HttpPut]
        public async Task<IActionResult> AlterEmpresa([FromBody] EmpresaAlterarRequest empresaRequest)
        {
            return await RequestService<EmpresaAlterarRequest, long>(
             empresaRequest,
             result => result.Success ? Ok(result) : BadRequest(result.Message),
             message => BadRequest(message)
         );
        }

        [HttpGet]
        public async Task<IActionResult> ListarEmpresas([FromQuery] EmpresaListarRequest request)
        {
            return await RequestService<EmpresaListarRequest, List<EmpresaDto>>(
                request,
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresaById(int id)
        {
            var request = new GetEmpresaByIdRequest(id);
            return await RequestService<GetEmpresaByIdRequest, EmpresaDto>(
                request,
                result => result.Success ? Ok(new { empresa = result.Data }) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }


    }
}
