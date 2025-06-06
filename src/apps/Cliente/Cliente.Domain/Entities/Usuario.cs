using System.ComponentModel.DataAnnotations;
using  Cliente.Domain.Comum;

namespace  Cliente.Domain.Entities
{

    public class Usuario : EntidadeBase
    {


        public int IdConfiguracaoPerfil { get; set; }


        public int IdTipoUsuario { get; set; }


        [MaxLength(200)]
        public string Nome { get; set; }


        [MaxLength(200)]
        public string Email { get; set; }


        [MaxLength(100)]
        public string CodigoKeycloak { get; set; }


        public int Situacao { get; set; } // Enum (0 - Inativo, 1 - Ativo)


        public DateTime? DataInativacao { get; set; }


        public DateTime? DataExclusao { get; set; }

     
    }
}
