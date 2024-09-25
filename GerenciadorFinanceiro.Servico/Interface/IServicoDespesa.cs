using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Servico.EntidadeVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Servico.Interface
{
    public interface IServicoDespesa
    {
        Task AdicionarSalvar(DespesaVO despesaVO);
        Task<IEnumerable<DespesaVO>> ObterTodos();
        Task<DespesaVO> ObterPorID(Guid Id);
        Task<DespesaVO> Atualizar(DespesaVO despesaVO);
        Task StatusDeletado(Guid Id);
        Task<IEnumerable<DespesaVO>> ObterDespesasComDetalhes();
    }
}
