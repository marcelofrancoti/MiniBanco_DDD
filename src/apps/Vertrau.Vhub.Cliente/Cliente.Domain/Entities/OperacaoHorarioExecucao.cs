using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{

    public class OperacaoHorarioExecucao : EntidadeBase
    {

        
        public int IdOperacao { get; set; }

        
        public TimeSpan Hora { get; set; }

        
        
    }
}
