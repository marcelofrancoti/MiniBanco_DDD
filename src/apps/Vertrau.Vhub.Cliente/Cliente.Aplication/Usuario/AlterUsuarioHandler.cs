using MediatR;
using  Cliente.Aplication.Usuario.Request;
using  Cliente.Contracts;
using  Cliente.Infrasctruture.Services;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Usuario.Handlers
{
    public class AlterUsuarioHandler : IRequestHandler<AlterUsuarioRequest, Response<long>>
    {
        private readonly UsuarioCommandStore _usuarioCommandStore;
        private readonly UsuarioEmpresaCommandStore _usuarioEmpresaCommandStore;

        public AlterUsuarioHandler(UsuarioCommandStore usuarioCommandStore, UsuarioEmpresaCommandStore usuarioEmpresaCommandStore)
        {
            _usuarioCommandStore = usuarioCommandStore;
            _usuarioEmpresaCommandStore = usuarioEmpresaCommandStore;
        }

        public async Task<Response<long>> Handle(AlterUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuarioDto = request.usuarioDto;

            // Fetch the user from the database
            var usuario = await _usuarioCommandStore.ObterUsuarioPorIdAsync(usuarioDto.Id);
            if (usuario == null || usuario.DataExclusao.HasValue)
            {
                return new Response<long>();
            }

            // Ensure email is unique
            var existingUsuario = await _usuarioCommandStore.GetByEmailAsync(usuarioDto.Email, usuarioDto.Id);
            if (existingUsuario != null)
            {
                return new Response<long>();
            }

            // Update user details
            usuario.Nome = usuarioDto.Nome;
            usuario.Email = usuarioDto.Email;
            usuario.IdConfiguracaoPerfil = usuarioDto.IdConfiguracaoPerfil;
            usuario.IdTipoUsuario = usuarioDto.TpUsuario;
            usuario.Situacao = usuarioDto.Situacao;

            // Update company associations
            if (usuarioDto.TpUsuario == 2)
            {
                var empresasAtuais = await _usuarioEmpresaCommandStore.ObterEmpresasPorUsuarioIdAsync(usuarioDto.Id);
                var novasEmpresas = usuarioDto.IdEmpresas ?? new List<int>();

                var empresasRemovidas = empresasAtuais.Where(ea => !novasEmpresas.Contains(ea.IdEmpresa)).ToList();
                var empresasAdicionadas = novasEmpresas.Where(ne => !empresasAtuais.Select(ea => ea.IdEmpresa).Contains(ne)).ToList();

                // Remove old companies
                foreach (var empresaRemovida in empresasRemovidas)
                {
                    await _usuarioEmpresaCommandStore.RemoverUsuarioEmpresaAsync(usuarioDto.Id, empresaRemovida.IdEmpresa);
                }

                // Add new companies
                foreach (var empresaAdicionada in empresasAdicionadas)
                {
                    await _usuarioEmpresaCommandStore.InserirUsuarioEmpresaAsync(usuarioDto.Id, empresaAdicionada);
                }
            }

            // Persist user updates
            var updatedId = await _usuarioCommandStore.AlterarUsuarioAsync(usuario);

            return new Response<long>
            {
                Data = updatedId,
                Success = true,
                Message = "Usuario Alterado com sucesso!"
            };
        }
    }
}
