using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class CessionarioCommandStore
    {
        private readonly Context _context;

        public CessionarioCommandStore(Context context)
        {
            _context = context;
        }

        public async Task<long> InserirFundoAsync(Cessionario fundo)
        {
            _context.Cessionario.Add(fundo); await _context.SaveChangesAsync(); return fundo.Id;
        }

        public async Task<long> AlterarCessionarioAsync(Cessionario cessionario)
        {
            // Verificar se o fundo existe no banco de dados
            var fundoExistente = await _context.Cessionario.FindAsync(cessionario.Id);
            if (fundoExistente == null) return 0;

            // Usar ExecuteUpdateAsync para atualizar as propriedades específicas
            await _context.Cessionario
                .Where(f => f.Id == cessionario.Id)
                .ExecuteUpdateAsync(f => f
                    .SetProperty(e => e.Cnpj, cessionario.Cnpj)
                    .SetProperty(e => e.Nome, cessionario.Nome)
                );

            return cessionario.Id;
        }


        public async Task<long> ExcluirCessionarioAsync(long id)
        {
            var fundo = await _context.Cessionario.FindAsync(id);

            if (fundo == null) return 0;
            _context.Cessionario.Remove(fundo); await _context.SaveChangesAsync();
            return fundo.Id  ;
        }
    }
}
