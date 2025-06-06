using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Cliente.Intrastruture.Services.InsegracaoService.EntidadesKeyCloack
{
    public class KeycloakCredential
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Temporary { get; set; }
        public long CreatedDate { get; set; }
    }
}
