using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{

    public class OperacaoParametro : EntidadeBase
    {

        
        public int IdOperacao { get; set; }

        
        public int IdAdministradorParametro { get; set; }

        
        [MaxLength(600)]
        public string Valor { get; set; }

        
        
    }
}
