using GerenciadorFinanceiro.Dominio.Entidades;

namespace GerenciadorFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioDespesa : IRepositorioBase<Despesa>
    {
        Task<IEnumerable<Despesa>> ObterDespesasComDetalhes();
    }
}
