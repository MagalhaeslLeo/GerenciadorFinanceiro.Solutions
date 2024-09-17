using GerenciadorFinanceiro.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorFinanceiro.Infra.DBContexto
{
    public class Contexto : DbContext
    {
        public DbSet<Despesa> Despesa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
