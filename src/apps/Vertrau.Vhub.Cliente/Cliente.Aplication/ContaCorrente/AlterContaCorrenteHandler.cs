using MediatR;
using  Cliente.Aplication.ContaCorrente.Request;
using  Cliente.Contracts;
using  Cliente.Intrastruture.Services;

namespace  Cliente.Aplication
{
    public class AlterContaCorrenteHandler : IRequestHandler<ContaCorrenteAlterarRequest, Response<long>>
    {
        private readonly ContaCorrenteCommandStore _commandStore;

        public AlterContaCorrenteHandler(ContaCorrenteCommandStore commandStore)
        {
            _commandStore = commandStore;
        }

        public async Task<Response<long>> Handle(ContaCorrenteAlterarRequest request, CancellationToken cancellationToken)
        {
            // Validar campos obrigatórios
            if (request.contaCorrente.Banco <= 0 || request.contaCorrente.Conta <= 0 || request.contaCorrente.Agencia <= 0)
            {
                return new Response<long> { Success = false, Message = "Campos obrigatórios não foram enviados, tente novamente" };
            }

            // Obter conta corrente existente
            var contaCorrent = new Domain.Entities.ContaCorrente
            {
                Id = request.contaCorrente.Id,
                IdBanco = request.contaCorrente.Banco,
                Conta = request.contaCorrente.Conta,
                Agencia = request.contaCorrente.Agencia,
                AgenciaDigito = request.contaCorrente.AgenciaDigito

            };

            // Lógica de atualização de `data_inativacao` baseada em `situacao`
            if (request.contaCorrente.Situacao == "0")
            {
                contaCorrent.DataInativacao = DateTime.UtcNow;
            }
            else if (request.contaCorrente.Situacao == "1")
            {
                contaCorrent.DataInativacao = null;
            }

            var rowsAffected = await _commandStore.AlterarContaCorrenteAsync(contaCorrent);

            return rowsAffected > 0
                ? new Response<long> { Data = request.contaCorrente.Id, Success = true, Message = "ContaCorrente alterada com sucesso" }
                : new Response<long> { Data = 0, Success = false, Message = "Falha ao alterar ContaCorrente" };
        }
    }
}
