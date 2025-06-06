using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class Banco : EntidadeBase
    {

        [MaxLength(200)]
        public string Nome { get; set; } // Nome do banco

        [MaxLength(10)]
        public string CodigoBanco { get; set; } // Código do banco (ex.: "001" para Banco do Brasil)

    }
}
