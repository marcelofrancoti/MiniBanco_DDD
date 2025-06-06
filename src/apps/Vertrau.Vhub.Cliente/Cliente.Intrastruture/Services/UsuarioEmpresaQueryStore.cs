using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class UsuarioEmpresaQueryStore
    {

        private readonly Context _context;

        public UsuarioEmpresaQueryStore(Context context)
        {
            _context = context;
        }

        public async Task<List<UsuarioEmpresa>> ObterEmpresasPorUsuarioIdAsync(int idUsuario)
        {
            return await _context.UsuarioEmpresa
                .Where(ue => ue.IdUsuario == idUsuario)
                .ToListAsync();
        }
    }
}
