using MediatR;
using  Cliente.Aplication.TipoEmpresa.Request;
using  Cliente.Contracts;
using  Cliente.Contracts.Dto;

namespace  Cliente.Aplication
{
    public class ListTiposEmpresaHandler : IRequestHandler<ListTiposEmpresaRequest, Response<List<TipoEmpresaDto>>>
    {
        public async Task<Response<List<TipoEmpresaDto>>> Handle(ListTiposEmpresaRequest request, CancellationToken cancellationToken)
        {
            var tiposEmpresa = Enum.GetValues(typeof(Contracts.Enum.TipoEmpresa))
                                   .Cast<Contracts.Enum.TipoEmpresa>()
                                   .Select(tipo => new TipoEmpresaDto
                                   {
                                       Value = ((int)tipo).ToString(),
                                       Label = tipo.ToString()
                                   })
                                   .ToList();

            return new Response<List<TipoEmpresaDto>>
            {
                Data = tiposEmpresa,
                Success = true,
                Message = "Tipos de empresa obtidos com sucesso."

            };
        }
    }
}
