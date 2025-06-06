using Microsoft.EntityFrameworkCore;
using  Cliente.Aplication.Requisicoes;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class EmpresaQueryStore
    {
        private readonly Context _context;

        public EmpresaQueryStore(Context context)
        {
            _context = context;
        }

        public async Task<List<Empresa>> ListarEmpresasAsync()
        {
            return await _context.Empresa.ToListAsync();
        }

        public async Task<Empresa> BuscarEmpresaPorIdAsync(long id)
        {
            return await _context.Empresa.FindAsync(id);
        }

        public async Task<List<Empresa>> ListarEmpresasFiltradasAsync(EmpresaListarRequest request)
        {
            var query = _context.Empresa.AsQueryable();

            // Aplicar filtros
            if (!string.IsNullOrEmpty(request.Nome))
            {
                query = query.Where(e => e.Nome.Contains(request.Nome));
            }

            if (!string.IsNullOrEmpty(request.Cnpj))
            {
                query = query.Where(e => e.Cnpj == request.Cnpj);
            }

            if (request.Tipo.HasValue)
            {
                query = query.Where(e => e.Tipo == request.Tipo.Value);
            }

            if (request.Situacao.HasValue)
            {
                if (request.Situacao.Value == 1) // Ativo
                {
                    query = query.Where(e => e.DataInativacao == null);
                }
                else if (request.Situacao.Value == 2) // Inativo
                {
                    query = query.Where(e => e.DataInativacao != null);
                }
            }

            // Ordenação
            switch (request.Ordem?.ToLower())
            {
                case "nome":
                    query = request.OrdenarPor == "ASC" ? query.OrderBy(e => e.Nome) : query.OrderByDescending(e => e.Nome);
                    break;
                case "cnpj":
                    query = request.OrdenarPor == "ASC" ? query.OrderBy(e => e.Cnpj) : query.OrderByDescending(e => e.Cnpj);
                    break;
                case "tipo":
                    query = request.OrdenarPor == "ASC" ? query.OrderBy(e => e.Tipo) : query.OrderByDescending(e => e.Tipo);
                    break;
                case "situacao":
                    query = request.OrdenarPor == "ASC" ? query.OrderBy(e => e.DataInativacao) : query.OrderByDescending(e => e.DataInativacao);
                    break;
                default:
                    query = query.OrderBy(e => e.Id);
                    break;
            }

            // Paginação
            query = query.Skip((request.Pagina - 1) * request.PaginaQuantidadeRegistro)
                         .Take(request.PaginaQuantidadeRegistro);

            return await query.ToListAsync();
        }

    }
}
