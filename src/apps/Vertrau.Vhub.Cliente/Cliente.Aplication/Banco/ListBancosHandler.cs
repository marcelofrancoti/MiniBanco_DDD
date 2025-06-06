using MediatR;
using Cliente.Aplication.Banco.Request;
using Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.Banco
{
    public class ListBancosHandler : IRequestHandler<ListBancosRequest, Response<List<BancoDto>>>
    {
        public async Task<Response<List<BancoDto>>> Handle(ListBancosRequest request, CancellationToken cancellationToken)
        {
            // Mapeia o enum Bancos para BancoDto
            var bancos = Enum.GetValues(typeof(Bancos))
                             .Cast<Bancos>()
                             .Select(banco => new BancoDto
                             {
                                 Value = ((int)banco).ToString(),
                                 Label = banco.ToString().Replace("Banco", "Banco ")
                             })
                             .ToList();

            return new Response<List<BancoDto>>
            {
                Data = bancos,
                Success = true,
                Message = "Bancos obtidos com sucesso."
            };
        }
    }
}
