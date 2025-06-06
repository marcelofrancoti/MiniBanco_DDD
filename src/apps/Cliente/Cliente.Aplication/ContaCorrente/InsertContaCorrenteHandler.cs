using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication.ContaCorrente
{
    public class InsertContaCorrenteHandler : IRequestHandler<ContaCorrenteInserirRequest, Response<long>>
    {
        private readonly ContaCorrenteCommandStore _commandStore;

        public InsertContaCorrenteHandler(ContaCorrenteCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(ContaCorrenteInserirRequest request, CancellationToken cancellationToken)
        {
            var rowsAffected = await _commandStore.InserirContaCorrenteAsync(new Domain.Entities.ContaCorrente
            {
                Conta = request.ContaCorrenteDto.Conta,
                Agencia = request.ContaCorrenteDto.Agencia,
                AgenciaDigito = request.ContaCorrenteDto.Agencia,
                IdBanco = request.ContaCorrenteDto.Banco,
                DataRegistro = DateTime.UtcNow,

            });

            return rowsAffected > 0
                ? new Response<long> { Data = rowsAffected, Success = true, Message = "ContaCorrente inserida com sucesso" }
                : new Response<long> { Data = 0, Success = false, Message = "Falha ao inserir ContaCorrente" };
        }
    }
}
