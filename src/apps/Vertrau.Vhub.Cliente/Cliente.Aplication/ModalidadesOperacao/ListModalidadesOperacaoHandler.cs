using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ModalidadeOperacao
{
    public class ListModalidadesOperacaoHandler : IRequestHandler<ListModalidadesOperacaoRequest, Response<List<ModalidadeOperacaoDto>>>
    {
        public async Task<Response<List<ModalidadeOperacaoDto>>> Handle(ListModalidadesOperacaoRequest request, CancellationToken cancellationToken)
        {
            var modalidadesOperacao = new List<ModalidadeOperacaoDto>
            {
                new ModalidadeOperacaoDto { Value = "1", Label = "Desconto próprio" },
                new ModalidadeOperacaoDto { Value = "2", Label = "Antecipação de recebíveis" },
                new ModalidadeOperacaoDto { Value = "3", Label = "Empréstimo" },
                new ModalidadeOperacaoDto { Value = "4", Label = "Financiamento" },
                new ModalidadeOperacaoDto { Value = "5", Label = "Leasing" }
            };

            return new Response<List<ModalidadeOperacaoDto>>
            {
                Data = modalidadesOperacao,
                Success = true,
                Message = "Modalidades de operação obtidas com sucesso."
            };
        }
    }
}
