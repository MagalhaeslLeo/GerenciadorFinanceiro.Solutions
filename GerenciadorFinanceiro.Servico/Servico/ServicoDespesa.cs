using AutoMapper;
using GerenciadorFinanceiro.Dominio.Entidades;
using GerenciadorFinanceiro.Dominio.Interfaces;
using GerenciadorFinanceiro.Servico.EntidadeVO;
using GerenciadorFinanceiro.Servico.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFinanceiro.Servico.Servico
{

        public class ServicoDespesa : IServicoDespesa

        {

            protected readonly IMapper mapper;

            protected readonly IRepositorioDespesa repositorioDespesa;

            public ServicoDespesa(IMapper mapper, IRepositorioDespesa repositorioDespesa)

            {

                this.mapper = mapper;

                this.repositorioDespesa = repositorioDespesa;

            }

            public async Task AdicionarSalvar(DespesaVO despesaVO)

            {

                try

                {

                    var despesaEntidade = mapper.Map<Despesa>(despesaVO);

                    if (despesaEntidade.Id == Guid.Empty)

                    {

                        despesaEntidade.Id = Guid.NewGuid();

                    }

                    await repositorioDespesa.AdicionarSalvar(despesaEntidade);


                }

                catch (Exception expection)

                {

                    throw new Exception(expection.Message, expection);

                }

            }

            public async Task<DespesaVO> Atualizar(DespesaVO despesaVO)

            {

                try

                {

                    var converterDespesa = mapper.Map<Despesa>(despesaVO);

                    var despesa = await repositorioDespesa.Atualizar(converterDespesa);

                    var converterDespesaVO = mapper.Map<DespesaVO>(despesa);

                    return converterDespesaVO;

                }

                catch (Exception expection)

                {

                    throw new Exception(expection.Message, expection);

                }

            }

            public async Task<DespesaVO> ObterPorID(Guid Id)

            {

                try

                {

                    var despesa = await repositorioDespesa.ObterPorID(Id);

                    var despesaVO = mapper.Map<DespesaVO>(despesa);

                    return despesaVO;

                }

                catch (Exception expection)

                {

                    throw new Exception(expection.Message, expection);

                }

            }

            public async Task<IEnumerable<DespesaVO>> ObterTodos()

            {

                try

                {

                    var despesa = await repositorioDespesa.ObterTodos();

                    var despesaVO = mapper.Map<IEnumerable<DespesaVO>>(despesa);

                    return despesaVO;

                }

                catch (Exception expection)

                {

                    throw new Exception(expection.Message, expection);

                }

            }

            public async Task StatusDeletado(Guid Id)

            {

                try

                {

                    var despesa = await repositorioDespesa.ObterPorID(Id);

                    despesa.Deletado = true;

                    await repositorioDespesa.StatusDeletado(despesa);

                }

                catch (Exception expection)

                {

                    throw new Exception(expection.Message, expection);

                }

            }

        }

    }
