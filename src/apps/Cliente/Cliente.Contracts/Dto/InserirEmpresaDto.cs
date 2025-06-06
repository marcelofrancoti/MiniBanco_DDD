namespace  Cliente.Contracts.Dto
{
    public class InserirEmpresaDto
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int Tipo { get; set; }  // 1 - Empresa, 2 - Fornecedor, 3 - Ambos
        public int Situacao { get; set; }  // 0 - Inativo, 1 - Ativo
    }
}
