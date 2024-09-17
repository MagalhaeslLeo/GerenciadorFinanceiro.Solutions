using AutoMapper;
using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Servico.EntidadeVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Servico.Mapeamento
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<DespesaVO, Despesa>().ReverseMap();
        }
    }
}
