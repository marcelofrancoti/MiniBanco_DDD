using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Aplication.Usuario.Request;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture;
using VHub.API.Controller.ConfigureBase;

namespace VHub.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        public UsuarioController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> InsertUsuario([FromBody] InsertUsuarioRequest request)
        {
            return await RequestService<InsertUsuarioRequest, long>(
                request,
                result => result.Success ? CreatedAtAction(nameof(GetUsuarioById), new { idUsuario = result.Data }, result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios([FromQuery] ListUsuariosRequest request)
        {
            return await RequestService<ListUsuariosRequest, List<UsuarioDto>>(
                request,
                result => result.Success ? Ok(result.Data) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetUsuarioById(int idUsuario)
        {
            var request = new GetIdUsuarioRequest { IdUsuario = idUsuario };
            return await RequestService<GetIdUsuarioRequest, UsuarioDto>(
                request,
                result => result.Success ? Ok(new { usuario = result.Data }) : NotFound(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpPatch("{idUsuario}")]
        public async Task<IActionResult> PatchUsuario(int idUsuario, [FromBody] AlterUsuarioRequest request)
        {
            request.usuarioDto.Id = idUsuario;
            return await RequestService<AlterUsuarioRequest, long>(
                request,
                result => result.Success ? Ok(result) : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }

        [HttpDelete("{idUsuario}")]
        public async Task<IActionResult> DeleteUsuario(int idUsuario)
        {
            var request = new DeleteUsuarioRequest(idUsuario);
            return await RequestService<DeleteUsuarioRequest, long>(
                request,
                result => result.Success ? NoContent() : BadRequest(result.Message),
                message => BadRequest(message)
            );
        }
    }
}
