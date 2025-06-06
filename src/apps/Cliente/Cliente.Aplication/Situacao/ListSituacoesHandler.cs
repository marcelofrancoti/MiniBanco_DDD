using MediatR;
using  Cliente.Aplication.Situacao.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Situacao
{
    public class ListSituacoesHandler : IRequestHandler<ListSituacoesRequest, Response<List<SituacaoDto>>>
    {
        public async Task<Response<List<SituacaoDto>>> Handle(ListSituacoesRequest request, CancellationToken cancellationToken)
        {
            var situacoes = new List<SituacaoDto>
            {
                new SituacaoDto { Value = "0", Label = "Inativo" },
                new SituacaoDto { Value = "1", Label = "Ativo" }
            };

            return new Response<List<SituacaoDto>>
            {
                Data = situacoes,
                Success = true,
                Message = "Situações obtidas com sucesso."
            };
        }
    }
}
