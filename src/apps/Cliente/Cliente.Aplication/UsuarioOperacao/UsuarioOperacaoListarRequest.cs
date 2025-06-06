using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication.UsuarioOperacao
{
    public class UsuarioOperacaoListarRequest : IRequest<Response<List<UsuarioOperacaoDto>>>
    {
    }
}
