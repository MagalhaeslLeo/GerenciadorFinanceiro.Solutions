using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Dominio.Interfaces;
using GerenciadorFinanceiro.Servico.EntidadeVO;
using GerenciadorFinanceiro.Servico.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanceiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        protected readonly IServicoDespesa service;
        public DespesaController(IServicoDespesa service)
        {
            this.service = service;
        }

        [HttpGet("ObterDespesasComDetalhes")]
        public async Task<IEnumerable<DespesaVO>> ObterDespesasComDetalhes()
        {
            try
            {
                var listaDespesa = await service.ObterDespesasComDetalhes();
                return listaDespesa;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<DespesaVO>> ObterTodos()
        {
            try
            {
                var listaDespesa = await service.ObterTodos();
                return listaDespesa;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
