using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;


namespace  Cliente.Aplication.Usuario.Request
{
    public class ListUsuarioRequest : IRequest<Response<List<UsuarioDto>>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? IdGrupoEconomico { get; set; }
        public string? TipoUsuario { get; set; }
        public string? Situacao { get; set; }
        public string? IdConfiguracaoPerfil { get; set; }  // Adicionado
        public string Ordenacao { get; set; } = "ASC";
        public string OrdenacaoColuna { get; set; } = "nome";
        public int Pagina { get; set; } = 1;
        public int PaginaQuantidadeRegistro { get; set; } = 50;
    }
}