using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Requisicoes
{
    public class EmpresaListarRequest : IRequest<Response<List<EmpresaDto>>>
    {
        public int Pagina { get; set; } = 1;
        public int PaginaQuantidadeRegistro { get; set; } = 10;
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public int? Tipo { get; set; } // Enum: 1 - Empresa, 2 - Fornecedor, 3 - Ambos
        public int? Situacao { get; set; } // Enum: 1 - Ativo, 2 - Inativo
        public string? Ordem { get; set; } // Nome, CNPJ, Tipo, Situacao
        public string OrdenarPor { get; set; } = "ASC"; // ASC ou DESC
    }
}
