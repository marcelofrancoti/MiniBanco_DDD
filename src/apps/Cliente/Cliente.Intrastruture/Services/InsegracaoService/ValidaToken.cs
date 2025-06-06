using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using  Cliente.Migrations;

namespace  Cliente.Intrastruture.Services.InsegracaoService
{
    public class ValidaTokenFilter : IActionFilter
    {
        private readonly Context _context;

        public ValidaTokenFilter(Context context)
        {
            _context = context;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"]))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    var usuarioId = jsonToken.Claims.ToList().Where(f => f.Type == "preferred_username").FirstOrDefault().ToString().Split(':')[1].Trim();

                    if (string.IsNullOrEmpty(usuarioId))
                    {
                        context.Result = new UnauthorizedResult();
                    }

                    var user = _context.Usuario.Where(f => f.Id.Equals(usuarioId));

                    if (user == null)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
                else
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Execution-Result", "Success");
        }
    }
}
