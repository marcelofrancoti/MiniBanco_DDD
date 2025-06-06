namespace  Cliente.Contracts.Dto
{
    public class InsertUsuarioDto
    {
        public int? IdGrupoEconomico { get; set; }
        public int IdConfiguracaoPerfil { get; set; }
        public int TpUsuario { get; set; }
        public int TpSituacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<int> IdEmpresas { get; set; }

        // Adicionando a propriedade Realm
        public string Realm { get; set; }
    }

}
