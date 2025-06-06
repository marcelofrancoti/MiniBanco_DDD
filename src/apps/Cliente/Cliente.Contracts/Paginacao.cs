namespace  Cliente.Contracts
{
    public class Paginacao<T>
    {
        public Paginacao(int paginaAtual, int paginaQuantidadeRegistros, int quantidadeTotalRegistros, T data)
        {
            PaginaAtual = paginaAtual;
            PaginaQuantidadeRegistros = paginaQuantidadeRegistros;
            QuantidadeTotalRegistros = quantidadeTotalRegistros;
            Data = data;
        }

        public T Data { get; set; }
        public int PaginaAtual { get; set; }
        public int PaginaQuantidadeRegistros { get; set; }
        public int QuantidadeTotalRegistros { get; set; }
    }
}
