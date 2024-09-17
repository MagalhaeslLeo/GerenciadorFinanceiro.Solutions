using GerenciadorFinanceiro.Dominio.IdBase;
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
    public class RepositorioBase<T> : IRepositorioBase<T> where T : Identity
    {
        protected readonly Contexto contexto;
        protected DbSet<T> dbSet;
        public RepositorioBase(Contexto contexto)
        {
            this.contexto = contexto;
            this.dbSet = contexto.Set<T>();
        }
        public async Task Commit()
        {
            try
            {
                await contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
        }
        public IQueryable<T> Queryable()
        {
            return dbSet as IQueryable<T>;
        }
        public void Adicionar(T entidade)
        {
            try
            {
                if (entidade.Id == Guid.Empty)
                {
                    entidade.Id = Guid.NewGuid();
                }
                dbSet.Add(entidade);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public async Task<T> AdicionarSalvar(T entidade)
        {
            try
            {
                if (entidade.Id == Guid.Empty)
                {
                    entidade.Id = Guid.NewGuid();
                }

                dbSet.Add(entidade);
                await contexto.SaveChangesAsync();
                return entidade;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
        }

        public async Task<T> Atualizar(T entidade)
        {
            try
            {
                var atualizaEntidade = await dbSet.SingleOrDefaultAsync(e => e.Id.Equals(entidade.Id));

                if (atualizaEntidade == null)
                {
                    return null;
                }
                contexto.Entry(atualizaEntidade).CurrentValues.SetValues(entidade);
                await contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
            return entidade;
        }

        public async Task<T> ObterPorID(Guid Id)
        {
            try
            {
                return await dbSet.SingleOrDefaultAsync(e => e.Id == Id);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
        }

        public async Task StatusDeletado(T entidade)
        {
            try
            {
                await contexto.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);

            }
        }
    }
}
        