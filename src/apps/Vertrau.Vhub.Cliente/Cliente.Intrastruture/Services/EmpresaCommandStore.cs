using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class EmpresaCommandStore
    {
        private readonly Context _context;

        public EmpresaCommandStore(Context context)
        {
            _context = context;
        }

        public async Task<long> InserirEmpresaAsync(Empresa empresa)
        {
            _context.Empresa.Add(empresa); await _context.SaveChangesAsync(); return empresa.Id;
        }

        public async Task<long> AlterarEmpresaAsync(Empresa empresa)
        {
            var empresaExistente = await _context.Empresa.FindAsync(empresa.Id);

            if (empresaExistente == null) return 0;
            empresaExistente.Nome = empresa.Nome;


            await _context.SaveChangesAsync(); return empresa.Id;
        }

        public async Task<long> ExcluirEmpresaAsync(int id)
        {
            var empresa = await _context.Empresa.FindAsync(id);

            if (empresa == null) return 0;
            _context.Empresa.Remove(empresa); await _context.SaveChangesAsync();
            return empresa.Id;
        }
    }
}
