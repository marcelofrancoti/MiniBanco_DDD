namespace  Cliente.Contracts.Dto
{
    public class InserirOperacaoDto
    {
        public int IdCessionario { get; set; }
        public int IdModalidadeOperacao { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public int ContaCobranca { get; set; }
        public int Situacao { get; set; }
        public List<string> HorariosExecucao { get; set; }
        public List<OperacaoParametroDto> Parametros { get; set; }
        public List<OperacaoEmpresaDto> Empresas { get; set; }
        

    }
}
