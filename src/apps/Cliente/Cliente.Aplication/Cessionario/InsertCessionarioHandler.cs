using MediatR;
using  Cliente.Aplication.Cessionario.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.Cessionario
{
    public class InsertCessionarioHandler : IRequestHandler<CessionarioInserirRequest, Response<long>>
    {
        private readonly CessionarioCommandStore _commandStore;

        public InsertCessionarioHandler(CessionarioCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(CessionarioInserirRequest request, CancellationToken cancellationToken)
        {
            var id = await _commandStore.InserirFundoAsync(new Domain.Entities.Cessionario {
            Cnpj = request.CessionarioDto.Cnpj,
            Nome = request.CessionarioDto.Nome,
            IdBancoCustodiante = 1
            
            
            });

            return new Response<long>
            {
                Data = id,
                Success = true,
                Message = "Fundo inserido com sucesso"
            };
        }
    }
}
