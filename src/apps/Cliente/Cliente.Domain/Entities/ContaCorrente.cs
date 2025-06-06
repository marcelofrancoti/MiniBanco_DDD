using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{
    public class ContaCorrente : EntidadeBase
    {


        public int IdBanco { get; set; } // Banco associado

        public int Conta { get; set; } // Número da conta

        public int Agencia { get; set; } // Número da agência

        public int AgenciaDigito { get; set; } // Dígito da agência

        public DateTime? DataInativacao { get; set; } // Data de inativação, opcional

        
    }
}
