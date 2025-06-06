using System.ComponentModel.DataAnnotations;

namespace  Cliente.Contracts.Dto
{
    public class OperacaoDto
    {
        public long Id { get; set; }
        public int IdCessionario { get; set; } 
        public int IdModalidadeOperacao { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int ContaCobranca { get; set; }
        public DateTime? DataInativacao { get; set; }

    }
}
