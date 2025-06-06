using  Cliente.Contracts.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using  Cliente.Migrations;

namespace  Cliente.Aplication.Operacao
{
    public class OperacaoQueryStore 
    {
        private readonly Context _context;

        public OperacaoQueryStore(Context context)
        {
            _context = context;
        }

        public async Task<List<OperacaoDto>> GetOperacoesAsync()
        {
            return await _context.Operacao
                 .Where(u => u.DataInativacao.HasValue)
                 .Select(o => new OperacaoDto
                 {
                     Id = o.Id,
                     IdCessionario = o.IdCessionario,
                     IdModalidadeOperacao = o.IdModalidadeOperacao,
                     Nome = o.Nome,
                     Detalhe = o.Detalhe,
                     ContaCobranca = o.ContaCobranca,
                     DataInativacao = o.DataInativacao
                 })
                 .ToListAsync();
        }
    }
}
