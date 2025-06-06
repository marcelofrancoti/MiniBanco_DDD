using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  Cliente.Aplication.Operacao.Request;
using  Cliente.Contracts;
using  Cliente.Domain.Entities;
using  Cliente.Intrastruture.Services;
using  Cliente.Migrations;

namespace  Cliente.Aplication.Operacao
{
    public class InserirOperacaoHandler : IRequestHandler<OperacaoInserirRequest, Response<long>>
    {
        public OperacaoCommandStore _operacaoCommandStore;

        public InserirOperacaoHandler(OperacaoCommandStore operacaoCommandStore)
        {
            _operacaoCommandStore = operacaoCommandStore;
        }

        public async Task<Response<long>> Handle(OperacaoInserirRequest request, CancellationToken cancellationToken)
        {
            // Validate required fields
            if (string.IsNullOrEmpty(request.InserirOperacaoDto.Nome) || string.IsNullOrEmpty(request.InserirOperacaoDto.Detalhe) ||
                request.InserirOperacaoDto.HorariosExecucao == null || request.InserirOperacaoDto.Empresas == null || request.InserirOperacaoDto.Empresas.Count == 0)
            {
                return new Response<long>
                {
                    Success = false,
                    Message = "Campos obrigatórios não foram enviados, tente novamente"
                };
            }

            // Create new Operacao entity
            var operacao = new  Cliente.Domain.Entities.Operacao
            {
                IdCessionario = request.InserirOperacaoDto.IdCessionario,
                IdModalidadeOperacao = request.InserirOperacaoDto.IdModalidadeOperacao,
                Nome = request.InserirOperacaoDto.Nome,
                Detalhe = request.InserirOperacaoDto.Detalhe,
                ContaCobranca = request.InserirOperacaoDto.ContaCobranca,
                DataInativacao = request.InserirOperacaoDto.Situacao == 0 ? DateTime.Now : (DateTime?)null
            };

            operacao.Parametros = new List<OperacaoParametro>();
            foreach (var item in request.InserirOperacaoDto.Parametros)
            {
                var parametro = new OperacaoParametro();
                parametro.Valor = item.Valor;
                parametro.IdAdministradorParametro = item.IdAdministradorParametro;
                operacao.Parametros.Add(parametro);
            }


            operacao.Cedentes = new List<OperacaoCedente>();

       
        //        public int IdOperacao { get; set; }
        //public int IdEmpresa { get; set; }
        //public bool Coobrigacao { get; set; }

            //_context.Operacoes.Add(operacao);
            //await _context.SaveChangesAsync(cancellationToken);

            // Insert HorariosExecucao
            //foreach (var horario in request.InserirOperacaoDto.HorariosExecucao)
            //{
            //    request.InserirOperacaoDto.HorariosExecucao.Add(horario);
            //}

            //// Insert Empresas
            //foreach (var empresa in request.Empresas)
            //{
            //    var operacaoCedente = new OperacaoCedente
            //    {
            //        IdOperacao = operacao.Id,
            //        IdEmpresa = empresa.IdEmpresa,
            //        Coobrigacao = empresa.Coobrigacao
            //    };
            //    _context.OperacaoCedentes.Add(operacaoCedente);
            //}

            // Insert Parametros (optional)
            //if (request.InserirOperacaoDto.Parametros != null)
            //{
            //    foreach (var parametro in request.Parametros)
            //    {
            //        var operacaoParametro = new OperacaoParametro
            //        {
            //            IdOperacao = operacao.Id,
            //            IdAdministradorParametro = parametro.IdAdministradorParametro,
            //            Valor = parametro.Valor
            //        };
            //        _context.OperacaoParametros.Add(operacaoParametro);
            //    }
            //}

            //await _context.SaveChangesAsync(cancellationToken);

            return new Response<long>
            {
                Success = true,
                Message = "Operação criada com sucesso.",
                Data = operacao.Id
            };
        }
    }
}

