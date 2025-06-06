namespace  Cliente.Contracts.Dto
{
    public class UsuarioAlterDto
    {
        public int Id { get; set; }
        public int IdConfiguracaoPerfil { get; set; }
        public int TpUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Situacao { get; set; }
        public List<int> IdEmpresas { get; set; }
    }
}
