using MediatR;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Cessionario
{
    public class DeleteCessionarioHandler : IRequestHandler<CessionarioExcluirRequest, Response<long>>
    {
        private readonly CessionarioCommandStore _commandStore;

        public DeleteCessionarioHandler(CessionarioCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(CessionarioExcluirRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _commandStore.ExcluirCessionarioAsync(request.IdCessionario);

            return new Response<long>
            {
                Data = rowsAffected,
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? "Cessionario excluído com sucesso" : "Erro ao excluir"
            };
        }
    }
}
