using MediatR;
using  Cliente.Aplication.Empresa.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Empresa
{
    public class DeleteEmpresaHandler : IRequestHandler<EmpresaExcluirRequest, Response<long>>
    {
        private readonly EmpresaCommandStore _commandStore;

        public DeleteEmpresaHandler(EmpresaCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(EmpresaExcluirRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _commandStore.ExcluirEmpresaAsync(request.IdEmpresa);

            if (rowsAffected > 0)
            {
                return new Response<long>
                {
                    Data = rowsAffected,
                    Success = true,
                    Message = "Empresa excluída com sucesso"
                };
            }

            return new Response<long>
            {
                Data = 0,
                Success = false,
                Message = "Falha ao excluir empresa"
            };
        }
    }
}
