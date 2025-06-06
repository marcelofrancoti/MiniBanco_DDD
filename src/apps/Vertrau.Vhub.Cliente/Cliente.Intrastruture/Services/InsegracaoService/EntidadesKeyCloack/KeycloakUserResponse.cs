using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack
{
    public class KeycloakUserResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public bool Enabled { get; set; }
        public string KeycloakId { get; set; }
    }
}
