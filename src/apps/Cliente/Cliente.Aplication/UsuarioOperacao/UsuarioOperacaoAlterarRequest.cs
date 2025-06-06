using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.UsuarioOperacao
{
    public class UsuarioOperacaoAlterarRequest : IRequest<Response<int>>
    {
        public UsuarioOperacaoDto UsuarioOperacaoDto { get; set; }
    }
}
