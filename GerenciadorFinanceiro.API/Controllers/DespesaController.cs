using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanceiro.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        protected readonly IRepositorioDespesa repDespesa;
        public DespesaController(IRepositorioDespesa repDespesa)
        {
            this.repDespesa = repDespesa;
        }

        [HttpGet]
        public async Task<IEnumerable<Despesa>> ObterDespesasComDetalhe()
        {
            var listaDespesa = await repDespesa.ObterDespesasComDetalhes();    
            return listaDespesa;
        }
    }
}
