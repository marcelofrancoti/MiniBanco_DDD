
namespace  Cliente.Contracts.Dto
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string Perfil { get; set; }
        public string Situacao { get; set; }
        public AcoesDto Acoes { get; set; }
        public string? CdKeyCloak { get; set; }
        public List<int> IdEmpresas { get; set; }
        public int IdConfiguracaoPerfil { get; set; }
    }

    public class AcoesDto
    {
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
    }

    public class UsuarioListResponse
    {
        public List<UsuarioDto> Usuarios { get; set; }
    }

  
}
