using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class Empresa : EntidadeBase
    {
        
        [MaxLength(200)]
        public string Nome { get; set; }

        [MaxLength(30)]
        public string Cnpj { get; set; }

        public int Tipo { get; set; } // Tipo da empresa

        [MaxLength(100)]
        public string CodigoKeycloak { get; set; }

        public DateTime? DataInativacao { get; set; }

        
    }
}
