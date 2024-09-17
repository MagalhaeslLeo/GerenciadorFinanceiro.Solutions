using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Dominio.IdBase
{
    public class Identity
    {
        public Guid Id { get; set; }
        public bool Deletado { get; set; }

    }
}
