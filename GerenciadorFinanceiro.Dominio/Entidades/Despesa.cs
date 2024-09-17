using GerenciadorFinanceiro.Dominio.IdBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Dominio.Entidades
{
    public class Despesa : Identity
    {
        public string Descricao { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataDespesa { get; set; }
        public Guid IdCartao { get; set; }
        public Guid IdFormaDePagamento { get; set; }

    }
}
