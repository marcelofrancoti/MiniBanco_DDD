using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ContaCorrenteListarRequest : IRequest<Response<Paginacao<List<ListarContaCorrenteDto>>>>
    {
        public int? IdBanco { get; set; }
        public int? Conta { get; set; }
        public int? Agencia { get; set; }
        public int? Situacao { get; set; } // 0: Ativo, 1: Inativo, null: Todos
        public string? Ordenacao { get; set; } = "ASC";
        public string? OrdenacaoColuna { get; set; } = "conta";
        public int? Pagina { get; set; } = 1;
        public int? PaginaQuantidadeRegistro { get; set; } = 50;
    }
}
