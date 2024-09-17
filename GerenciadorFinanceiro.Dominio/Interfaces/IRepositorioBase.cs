using GerenciadorFinanceiro.Dominio.IdBase;

namespace GerenciadorFinanceiro.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : Identity
    {
        IQueryable<T> Queryable();
        Task Commit();
        void Adicionar(T entidade);
        Task<T> AdicionarSalvar(T entidade);
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorID(Guid Id);
        Task<T> Atualizar(T entidade);
        Task StatusDeletado(T entidade);
    }
}
