using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.ContaCorrente.Request
{
    public class ContaCorrenteInserirRequest : IRequest<Response<long>>
    {
        public InserirContaCorrenteDto ContaCorrenteDto { get; set; }
    }






}
