using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class Operacao : EntidadeBase
    {
        public int IdCessionario { get; set; } // FK para Cessionario
        public int IdModalidadeOperacao { get; set; }

        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(400)]
        public string Detalhe { get; set; }

        public int ContaCobranca { get; set; } // Enum (1, 2, 3)
        public DateTime? DataInativacao { get; set; }

        // Navigation properties
        public ICollection<OperacaoHorarioExecucao> HorariosExecucao { get; set; }
        public ICollection<OperacaoCedente> Cedentes { get; set; }
        public ICollection<OperacaoParametro> Parametros { get; set; }
    }
}
