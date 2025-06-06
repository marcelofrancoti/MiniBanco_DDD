using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.ContaCorrente
{
    public class DeleteContaCorrenteHandler : IRequestHandler<ContaCorrenteExcluirRequest, Response<long>>
    {
        private readonly ContaCorrenteCommandStore _commandStore;

        public DeleteContaCorrenteHandler(ContaCorrenteCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(ContaCorrenteExcluirRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _commandStore.ExcluirContaCorrenteAsync(request.IdContaCorrente);

            return rowsAffected > 0
                ? new Response<long> { Data = rowsAffected, Success = true, Message = "ContaCorrente excluída com sucesso" }
                : new Response<long> { Data = 0, Success = false, Message = "Falha ao excluir ContaCorrente" };
        }
    }
}
