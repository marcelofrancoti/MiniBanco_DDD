namespace  Cliente.Contracts.Dto
{
    public class ListarContaCorrenteDto
    {
        public long Id { get; set; }
        public string Banco { get; set; }
        public int Conta { get; set; }
        public int Agencia { get; set; }
        public string Situacao { get; set; }
    }
}
