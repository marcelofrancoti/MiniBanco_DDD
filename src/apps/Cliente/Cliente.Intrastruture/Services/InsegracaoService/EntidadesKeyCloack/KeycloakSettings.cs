using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack
{
    public class KeycloakSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TokenUrl { get; set; }
    }
}
