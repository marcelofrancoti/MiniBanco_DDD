using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Infrasctruture.Services
{
    public class UsuarioEmpresaCommandStore
    {
        private readonly Context _context;

        public UsuarioEmpresaCommandStore(Context context)
        {
            _context = context;
        }

        // Insert a new association between a user and a company
        public async Task InserirUsuarioEmpresaAsync(int idUsuario, int idEmpresa)
        {
            var usuarioEmpresa = new UsuarioEmpresa
            {
                IdUsuario = idUsuario,
                IdEmpresa = idEmpresa,
                DataRegistro = DateTime.UtcNow
            };

            _context.UsuarioEmpresa.Add(usuarioEmpresa);
            await _context.SaveChangesAsync();
        }

        // Remove the association between a user and a company
        public async Task RemoverUsuarioEmpresaAsync(int idUsuario, int idEmpresa)
        {
            var usuarioEmpresa = await _context.UsuarioEmpresa
                .FirstOrDefaultAsync(ue => ue.IdUsuario == idUsuario && ue.IdEmpresa == idEmpresa);

            if (usuarioEmpresa != null)
            {
                _context.UsuarioEmpresa.Remove(usuarioEmpresa);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all company associations for a given user
        public async Task<List<UsuarioEmpresa>> ObterEmpresasPorUsuarioIdAsync(int idUsuario)
        {
            return await _context.UsuarioEmpresa
                .Where(ue => ue.IdUsuario == idUsuario)
                .ToListAsync();
        }
    }
}
