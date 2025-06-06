using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class UsuarioCommandStore
    {
        private readonly Context _context;

        public UsuarioCommandStore(Context context)
        {
            _context = context;
        }

        // Inserir novo usuário na base de dados
        public async Task<long> InserirUsuarioAsync(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario.Id;  // Retorna o ID gerado
        }
        public async Task<Usuario> ObterUsuarioPorIdAsync(int idUsuario)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Id == idUsuario && u.DataExclusao == null);
        }
        public async Task<long> AlterarUsuarioAsync(Usuario usuario)
        {
            var existing = await _context.Usuario.FindAsync(usuario.Id);
            if (existing == null) return 0;

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;
            existing.IdConfiguracaoPerfil = usuario.IdConfiguracaoPerfil;
            existing.IdTipoUsuario = usuario.IdTipoUsuario;
            existing.Situacao = usuario.Situacao;

            await _context.SaveChangesAsync();
            return existing.Id;
        }
        // Atualizar o código Keycloak após inserção no Keycloak
        public async Task AtualizarCdKeycloakAsync(long idUsuario, string cdKeycloak)
        {
            var usuario = await _context.Usuario.FindAsync(idUsuario);
            if (usuario != null)
            {
                usuario.CodigoKeycloak = cdKeycloak;
                await _context.SaveChangesAsync();
            }
        }

        // Verificar se o e-mail já existe no banco de dados
        public async Task<Usuario> GetByEmailAsync(string email, int idUsuario)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Email == email && u.Id != idUsuario && u.DataExclusao == null);
        }

        public async Task AtualizarCdKeycloakAsync(long usuarioId, object keycloakId)
        {
            throw new NotImplementedException();
        }
    }

}
