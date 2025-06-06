using MediatR;
using Microsoft.AspNetCore.Http;
using  Cliente.Aplication.Usuario.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Application.Usuario
{
    public class GetIdUsuarioHandler : IRequestHandler<GetIdUsuarioRequest, Response<UsuarioDto>>
    {
        private readonly UsuarioQueryStore _usuarioQueryStore;
        private readonly UsuarioEmpresaQueryStore _usuarioEmpresaQueryStore;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetIdUsuarioHandler(UsuarioQueryStore usuarioQueryStore,
                                   UsuarioEmpresaQueryStore usuarioEmpresaQueryStore,
                                   IHttpContextAccessor httpContextAccessor)
        {
            _usuarioQueryStore = usuarioQueryStore;
            _usuarioEmpresaQueryStore = usuarioEmpresaQueryStore;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<UsuarioDto>> Handle(GetIdUsuarioRequest request, CancellationToken cancellationToken)
        {
            // Validate mandatory parameter idUsuario
            if (request.IdUsuario <= 0)
            {
                return new Response<UsuarioDto>()
                {
                    Success = false,
                    Message = ""
                };
            }

            // Get the user details
            var usuario = await _usuarioQueryStore.ObterUsuarioPorIdAsync(request.IdUsuario);
            if (usuario == null || usuario.DataExclusao.HasValue)
            {
                return new Response<UsuarioDto>()
                {
                    Success = false,
                    Message = ""

                };
            }

            // Fetch associated empresas
            var empresas = await _usuarioEmpresaQueryStore.ObterEmpresasPorUsuarioIdAsync(request.IdUsuario);

            // Fetch CdKeyCloak from JWT token (assuming it is part of the claims)
            var currentCdKeyCloak = _httpContextAccessor.HttpContext?.User?.FindFirst("CdKeyCloak")?.Value;

            // Define actions (editar, excluir)
            var acoes = new AcoesDto
            {
                Editar = !string.Equals(usuario.CodigoKeycloak, currentCdKeyCloak, StringComparison.OrdinalIgnoreCase),
                Excluir = !string.Equals(usuario.CodigoKeycloak, currentCdKeyCloak, StringComparison.OrdinalIgnoreCase)
            };

            // Map to UsuarioDto
            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoUsuario = usuario.IdTipoUsuario.ToString(), // Assuming TipoUsuario is enum-like
                Perfil = usuario.IdConfiguracaoPerfil.ToString(),
                Situacao = usuario.DataInativacao.HasValue ? "0" : "1", // 0 if inactivated, 1 if active
                IdEmpresas = empresas.Select(e => e.IdEmpresa).ToList(),
                Acoes = acoes,
                CdKeyCloak = usuario.CodigoKeycloak
            };

            return new Response<UsuarioDto>()
            {
                Success = true,
                Data = usuarioDto,
                Message = ""

            };
        }
    }
}
