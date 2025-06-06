namespace  Cliente.Contracts.Dto
{
    public class ContaCorrenteDto
    {
        public long Id { get; set; }
        public int Banco { get; set; }
        public int Conta { get; set; }
        public int Agencia { get; set; }
        public int AgenciaDigito { get; set; }
        public string Situacao { get; set; }
    }
}
