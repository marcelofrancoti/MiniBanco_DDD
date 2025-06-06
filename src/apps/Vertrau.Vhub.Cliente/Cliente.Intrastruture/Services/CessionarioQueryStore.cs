using Microsoft.EntityFrameworkCore;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class CessionarioQueryStore
    {
        private readonly Context _context;

        public CessionarioQueryStore(Context context)
        {
            _context = context;
        }

        public async Task<List<Cessionario>> ListarFundosAsync()
        {
            return await _context.Cessionario.ToListAsync();
        }

        public async Task<Cessionario> BuscarFundoPorIdAsync(int id)
        {
            return await _context.Cessionario.FindAsync(id);
        }

        public async Task<List<ListCessionarioDto>> GetCessionariosAsync(
            string nome,
            string cnpj,
            int? situacao,
            string ordenacao,
            string ordenacaoColuna,
            int offset,
            int limit)
        {
            var query = _context.Cessionario.AsQueryable();

            // Filtering
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => EF.Functions.Like(c.Nome, $"%{nome}%"));
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                query = query.Where(c => EF.Functions.Like(c.Cnpj, $"%{cnpj}%"));
            }

            if (situacao.HasValue)
            {
                query = situacao == 1
                    ? query.Where(c => c.DataInativacao != null)
                    : query.Where(c => c.DataInativacao == null);
            }

            // Sorting
            switch (ordenacaoColuna.ToLower())
            {
                case "cnpj":
                    query = ordenacao.ToLower() == "desc" ? query.OrderByDescending(c => c.Cnpj) : query.OrderBy(c => c.Cnpj);
                    break;
                case "situacao":
                    query = ordenacao.ToLower() == "desc" ? query.OrderByDescending(c => c.DataInativacao) : query.OrderBy(c => c.DataInativacao);
                    break;
                default:
                    query = ordenacao.ToLower() == "desc" ? query.OrderByDescending(c => c.Nome) : query.OrderBy(c => c.Nome);
                    break;
            }

            // Pagination
            var totalRegistros = await query.CountAsync();
            var cessionarios = await query.Skip(offset).Take(limit).ToListAsync();

            // Map to DTO
            var cessionarioList = cessionarios.Select(c => new ListCessionarioDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Cnpj = c.Cnpj,
                Situacao = c.DataInativacao == null ? "Ativo" : "Inativo"
            }).ToList();

            return cessionarioList;
        }

        public async Task<List<ListarCessionarioDto>> GetIdCessionariosAsync(long Id)
        {
            var query = _context.Cessionario.AsQueryable().Where(f => f.Id == Id && !f.DataInativacao.HasValue);

            var cessionarioList = query.Select(c => new ListarCessionarioDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Cnpj = c.Cnpj,
                Situacao = c.DataInativacao == null ? "Ativo" : "Inativo"
            }).ToList();

            return cessionarioList;
        }
    }
}
