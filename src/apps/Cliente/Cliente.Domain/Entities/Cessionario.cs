using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class Cessionario : EntidadeBase
    {

        public int IdAdministrador { get; set; }

        public int? IdBancoCustodiante { get; set; }

        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(30)]
        public string Cnpj { get; set; }

        public DateTime? DataInativacao { get; set; }

        public DateTime DataRegistro { get; set; }
    }
}
