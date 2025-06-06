using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class OperacaoCedente : EntidadeBase
    {

        
        public int IdOperacao { get; set; }

        
        public int IdEmpresa { get; set; }

        
        public bool Coobrigacao { get; set; }

        
        
    }
}
