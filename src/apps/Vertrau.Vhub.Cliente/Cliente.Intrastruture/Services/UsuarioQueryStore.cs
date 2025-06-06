using Microsoft.EntityFrameworkCore;
using  Cliente.Domain.Entities;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services
{
    public class UsuarioQueryStore
    {
        private readonly Context _context;

        public UsuarioQueryStore(Context context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ListarUsuariosAsync(ListUsuariosRequest request, int pagina, int paginaQuantidadeRegistro)
        {
            // Consulta inicial
            var query = _context.Usuario.Where(u => u.DataExclusao == null);

            if (!string.IsNullOrEmpty(request.Nome))
            {
                query = query.Select(f => f).Where(u => u.Nome.ToLower().Contains(request.Nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Select(f => f).Where(u => u.Email.ToLower().Contains(request.Email.ToLower()));
            }

            //if (request.TipoUsuario.HasValue)
            //{
            //    query = query.Where(u => u.IdTipoUsuario == request.TipoUsuario.Value);
            //}

            //if (request.Perfil.HasValue)
            //{
            //    query = query.Where(u => u.IdConfiguracaoPerfil == request.Perfil.Value);
            //}

            //if (request.Situacao.HasValue)
            //{
            //    if (request.Situacao.Value == 1)
            //    {
            //        query = query.Where(u => u.DataInativacao != null);
            //    }
            //    else if (request.Situacao.Value == 0)
            //    {
            //        query = query.Where(u => u.DataInativacao == null);
            //    }
            //}

            // Aplicar ordenação
            if (!string.IsNullOrEmpty(request.OrdenacaoColuna))
            {
                if (request.Ordenacao.Equals("DESC", StringComparison.OrdinalIgnoreCase))
                {
                    query = request.OrdenacaoColuna switch
                    {
                        "nome" => query.OrderByDescending(u => u.Nome),
                        "email" => query.OrderByDescending(u => u.Email),
                        "tipoUsuario" => query.OrderByDescending(u => u.IdTipoUsuario),
                        "perfil" => query.OrderByDescending(u => u.IdConfiguracaoPerfil),
                        _ => query.OrderByDescending(u => u.Nome) // Padrão para 'nome'
                    };
                }
                else
                {
                    query = request.OrdenacaoColuna switch
                    {
                        "nome" => query.OrderBy(u => u.Nome),
                        "email" => query.OrderBy(u => u.Email),
                        "tipoUsuario" => query.OrderBy(u => u.IdTipoUsuario),
                        "perfil" => query.OrderBy(u => u.IdConfiguracaoPerfil),
                        _ => query.OrderBy(u => u.Nome) // Padrão para 'nome'
                    };
                }
            }
            else
            {
                // Ordenação padrão por nome
                query = query.OrderBy(u => u.Nome);
            }

            // Paginação
            var offset = (pagina - 1) * paginaQuantidadeRegistro;
            return await query.Skip(offset).Take(paginaQuantidadeRegistro).ToListAsync();
        }

        public async Task<int> ContarUsuariosAsync(ListUsuariosRequest request)
        {
            var query = _context.Usuario.Where(u => u.DataExclusao == null);

            // Aplicar os mesmos filtros da listagem
            if (!string.IsNullOrEmpty(request.Nome))
            {
                query = query.Where(u => u.Nome.Contains(request.Nome));
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(u => u.Email.Contains(request.Email));
            }

            if (request.TipoUsuario.HasValue)
            {
                query = query.Where(u => u.IdTipoUsuario == request.TipoUsuario.Value);
            }

            if (request.Perfil.HasValue)
            {
                query = query.Where(u => u.IdConfiguracaoPerfil == request.Perfil.Value);
            }

            if (request.Situacao.HasValue)
            {
                if (request.Situacao.Value == 1)
                {
                    query = query.Where(u => u.DataInativacao != null);
                }
                else if (request.Situacao.Value == 0)
                {
                    query = query.Where(u => u.DataInativacao == null);
                }
            }

            return await query.CountAsync();
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(int idUsuario)
        {
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Id == idUsuario && u.DataExclusao == null);
        }

    }
}
