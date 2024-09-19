using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Dominio.Interfaces;
using GerenciadorFinanceiro.Infra.DBContexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Infra.Repositorio
{
    public class RepositorioDespesa : RepositorioBase<Despesa>, IRepositorioDespesa

    {

        public RepositorioDespesa(Contexto contexto) : base(contexto) { }

        public async Task<IEnumerable<Despesa>> ObterDespesasComDetalhes()

        {

            try

            {

                var query = await contexto.Despesa

                    .FromSqlRaw(@"
                                SELECT 
                                    desp.Id,
                                    formaPg.Descricao AS FormaPagamento,
                                    modalidade.DescricaoModalidade AS Modalidade,
                                    cartao.QuantidadeParcela,
                                    cartao.ValorParcela,
                                    cartao.Bandeira,
                                    cartao.ValorTotal AS ValorTotalParcela,
                                    desp.DataDespesa,
                                    desp.ValorTotal AS ValorTotalDespesa
                                FROM 
                                    FINDespesa desp
                                JOIN 
                                    DOMFormaDePagamento formaPg ON desp.IdFormaPagamento = formaPg.Id
                                JOIN 
                                    FINCartao cartao ON desp.IdCartao = cartao.Id
                                JOIN 
                                    DOMModalidadeDePagamento modalidade ON cartao.IdModalidadePagamento = modalidade.Id
                    ").ToListAsync();

                return query.AsEnumerable();

            }

            catch (Exception exception)

            {

                throw new Exception(exception.Message, exception);

            }

        }

    }


}
