using Microsoft.EntityFrameworkCore;
using  Cliente.Contracts.Dto;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class ContaCorrenteQueryStore
    {
        private readonly Context _context;

        public ContaCorrenteQueryStore(Context context)
        {
            _context = context;
        }

       
        public async Task<List<ListarContaCorrenteDto>> ListarContaCorrentesAsync(ListarContaCorrenteDto request)
        {
            var query = from conta in _context.ContaCorrente
                        join banco in _context.Banco on conta.IdBanco equals banco.Id
                        select new { conta, banco };

            // Filtragem
            if (request.Id > 0)
                query = query.Where(q => q.conta.IdBanco == request.Id);

            if (request.Conta > 0)
                query = query.Where(q => EF.Functions.Like(q.conta.Conta.ToString(), $"%{request.Conta}%"));

            if (request.Agencia > 0)
                query = query.Where(q => q.conta.Agencia == request.Agencia);

            if (request.Situacao == "Inativo")
                query = query.Where(q => q.conta.DataInativacao.HasValue);
            else if (request.Situacao == "Ativo")
                query = query.Where(q => !q.conta.DataInativacao.HasValue);

            // Ordenação
            var ordenacaoColuna = request.GetType().GetProperty("OrdenacaoColuna")?.GetValue(request, null) as string ?? "conta";
            var ordenacao = request.GetType().GetProperty("Ordenacao")?.GetValue(request, null) as string ?? "ASC";

            query = ordenacaoColuna.ToLower() switch
            {
                "banco" => ordenacao.Equals("DESC", StringComparison.OrdinalIgnoreCase) ? query.OrderByDescending(q => q.banco.Nome) : query.OrderBy(q => q.banco.Nome),
                "agencia" => ordenacao.Equals("DESC", StringComparison.OrdinalIgnoreCase) ? query.OrderByDescending(q => q.conta.Agencia) : query.OrderBy(q => q.conta.Agencia),
                _ => ordenacao.Equals("DESC", StringComparison.OrdinalIgnoreCase) ? query.OrderByDescending(q => q.conta.Conta) : query.OrderBy(q => q.conta.Conta),
            };

            // Projeção para ListarContaCorrenteDto
            var result = await query.Select(q => new ListarContaCorrenteDto
            {
                Id = q.conta.Id,
                Banco = q.banco.Nome, // Aqui pegamos o nome do banco
                Conta = q.conta.Conta,
                Agencia = q.conta.Agencia,
                Situacao = q.conta.DataInativacao.HasValue ? "Inativo" : "Ativo"
            }).ToListAsync();

            return result;
        }



        public async Task<List<ContaCorrenteDto>> GetIdContaCorrentesAsync(long Id)
        {
            var query = _context.ContaCorrente.AsQueryable().Where(f => f.Id == Id);

            // Projeção para ListarContaCorrenteDto
            var result = await query.Select(c => new ContaCorrenteDto
            {
                Id = c.Id,
                Banco = c.IdBanco, // Ajuste conforme necessário para obter o nome do banco
                Conta = c.Conta,
                Agencia = c.Agencia,
                Situacao = c.DataInativacao.HasValue ? "Inativo" : "Ativo"
            }).ToListAsync();

            return result;
        }

        public async Task<List<ContaCorrenteEnumDto>> ListarContasCorrentesAtivasAsync()
        {
            var query = from conta in _context.ContaCorrente
                        join banco in _context.Banco on conta.IdBanco equals banco.Id
                        where conta.DataInativacao == null
                        select new ContaCorrenteEnumDto
                        {
                            Value = conta.Id.ToString(),
                            Label = $"{banco.Nome} - {conta.Conta} - {conta.Agencia}-{conta.AgenciaDigito}"
                        };

            return await query.ToListAsync();
        }
    }
}
