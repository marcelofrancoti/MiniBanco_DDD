namespace  Cliente.Contracts.Dto
{
    public class ListarCessionarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Situacao { get; set; }
    }
}
