using MediatR;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication
{
    public class AlterCessionarioHandler : IRequestHandler<CessionarioAlterarRequest, Response<long>>
    {
        private readonly CessionarioCommandStore _commandStore;

        public AlterCessionarioHandler(CessionarioCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(CessionarioAlterarRequest request, CancellationToken cancellationToken)
        {
            var cessionario = new Domain.Entities.Cessionario
            {
                Id = request.CessionarioDto.Id,
                Cnpj = request.CessionarioDto.Cnpj,
                Nome = request.CessionarioDto.Nome
            };

            long rowsAffected = await _commandStore.AlterarCessionarioAsync(cessionario);

            return new Response<long>
            {
                Data = rowsAffected,
                Success = rowsAffected > 0,
                Message = rowsAffected > 0 ? "Alterado com sucesso" : "Erro ao alterar Fundo"
            };
        }
    }
}
