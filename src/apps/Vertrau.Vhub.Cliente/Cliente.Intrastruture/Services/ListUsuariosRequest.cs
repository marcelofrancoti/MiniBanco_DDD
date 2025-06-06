using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Intrastruture
{
    public class ListUsuariosRequest : IRequest<Response<List<UsuarioDto>>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public int? TipoUsuario { get; set; }
        public int? Perfil { get; set; }
        public int? Situacao { get; set; }
        public string? Ordenacao { get; set; } = "ASC";
        public string? OrdenacaoColuna { get; set; } = "nome";
        public int Pagina { get; set; } = 1;
        public int PaginaQuantidadeRegistro { get; set; } = 50;
    }
}
