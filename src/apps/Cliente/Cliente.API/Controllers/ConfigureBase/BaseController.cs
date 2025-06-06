using MediatR;
using Microsoft.AspNetCore.Mvc;
using  Cliente.Contracts;
using  Cliente.Migrations;

namespace VHub.API.Controller.ConfigureBase
{
    //    [ServiceFilter(typeof(ValidaTokenFilter))] 
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Context _context;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
            _context = new Context(new Microsoft.EntityFrameworkCore.DbContextOptions<Context>());
        }

        protected async Task<IActionResult> RequestService<TRequest, TResponse>(TRequest request, Func<Response<TResponse>, IActionResult> successResult, Func<string, IActionResult> failureResult) where TRequest : IRequest<Response<TResponse>>
        {
            var result = await _mediator.Send(request);

            if (result == null || !result.Success)
            {
                return failureResult(result?.Message ?? "Erro ao processar a requisição");
            }

            return successResult(result);
        }
    }
}
