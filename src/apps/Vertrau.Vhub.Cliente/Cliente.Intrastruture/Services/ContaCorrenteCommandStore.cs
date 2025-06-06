using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class ContaCorrenteCommandStore
    {
        private readonly Context _context;

        public ContaCorrenteCommandStore(Context context)
        {
            _context = context;
        }

        public async Task<long> InserirContaCorrenteAsync(ContaCorrente contaCorrente)
        {
            _context.ContaCorrente.Add(contaCorrente);
            await _context.SaveChangesAsync(); 
            return contaCorrente.Id;
        }

        public async Task<long> AlterarContaCorrenteAsync(ContaCorrente contaCorrente)
        {
            var contaExistente = await _context.ContaCorrente.FindAsync(contaCorrente.Id);

            if (contaExistente == null) return 0;

            // Atualizar os campos especificados usando ExecuteUpdateAsync
            await _context.ContaCorrente
                .Where(c => c.Id == contaCorrente.Id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(e => e.IdBanco, contaCorrente.IdBanco)
                    .SetProperty(e => e.Conta, contaCorrente.Conta)
                    .SetProperty(e => e.Agencia, contaCorrente.Agencia)
                    .SetProperty(e => e.AgenciaDigito, contaCorrente.AgenciaDigito)
                    .SetProperty(e => e.DataInativacao, contaCorrente.DataInativacao)
                );

            return contaCorrente.Id;
        }


        public async Task<long> ExcluirContaCorrenteAsync(long id)
        {
            var contaCorrente = await _context.ContaCorrente.FindAsync(id);

            if (contaCorrente == null) return 0;
            _context.ContaCorrente.Remove(contaCorrente); await _context.SaveChangesAsync();
            return contaCorrente.Id;
        }
    }
}
