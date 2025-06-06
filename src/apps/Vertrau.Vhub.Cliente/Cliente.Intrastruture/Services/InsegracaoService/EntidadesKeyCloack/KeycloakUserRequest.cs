using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack
{
    public class KeycloakUserRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public bool Enabled { get; set; }
        public string[] Groups { get; set; }
        public KeycloakCredential[] Credentials { get; set; }
    }
}
