using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Cessionario.Request
{
    public class CessionarioListarRequest : IRequest<Response<Paginacao<List<ListCessionarioDto>>>>
    {
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public int? Situacao { get; set; }
        public string Ordenacao { get; set; } = "ASC"; // Default ASC
        public string OrdenacaoColuna { get; set; } = "nome"; // Default "nome"
        public int Pagina { get; set; } = 1;
        public int PaginaQuantidadeRegistro { get; set; } = 50;
    }
}
