using MediatR;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;


namespace  Cliente.Aplication.Usuario.Request
{
    public class InsertUsuarioRequest : IRequest<Response<long>>
    {
 
        public InsertUsuarioDto Request { get; }

        public InsertUsuarioRequest(InsertUsuarioDto request)
        {
            Request = request;
        }
    }
}
