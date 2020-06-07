using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using QualityManagement.Frontier.Business.Entidades;
using QualityManagement.Frontier.Business.Service.Dominio;
using QualityManagement.Frontier.Repository.Entidades;
using QualityManagement.Frontier.Repository.Repositories.Dominio;
using QualityManagement.Util.Helpers;

namespace QualityManagement.Service.Dominio
{
    public class NaoConformidadeService : INaoConformidadeService
    {
        private readonly IMapper _mapper;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;

        public NaoConformidadeService(IMapper mapper, INaoConformidadeRepository naoConformidadeRepository)
        {
            _mapper = mapper;
            _naoConformidadeRepository = naoConformidadeRepository;
        }

        public void Registrar(NaoConformidade naoConformidade)
        {
            _naoConformidadeRepository.Registrar(_mapper.Map<NaoConformidadeEntidade>(naoConformidade));
        }

        public Task<RelatorioNaoConformidade> ObterDadosRelatorio()
        {
            RelatorioNaoConformidade relatorio = new RelatorioNaoConformidade();

            Task taskDadoPorTipo = 
                _naoConformidadeRepository.ObterDadoPorTipo().ContinueWith(
                    task => relatorio.QuantidadeNaoConformidadePorTipo =
                        _mapper.Map<IEnumerable<QuantidadeNaoConformidadePorTipo>>(task.Result));

            Task taskDadoPorPrioridade = 
                _naoConformidadeRepository.ObterDadoPorPrioridade().ContinueWith(
                    task => relatorio.QuantidadeNaoConformidadePorPrioridade =
                        _mapper.Map<IEnumerable<QuantidadeNaoConformidadePorPrioridade>>(task.Result));

            Task taskDadoPorMesEPrioridade = 
                _naoConformidadeRepository.ObterDadoPorMesEPrioridade().ContinueWith(
                    task => relatorio.QuantidadeNaoConformidadePorDataEPrioridade =
                        _mapper.Map<IEnumerable<QuantidadeNaoConformidadePorDataEPrioridade>>(task.Result));

            return AsyncHelper.ResultadoAsync<RelatorioNaoConformidade>(relatorio,
                taskDadoPorTipo, taskDadoPorPrioridade, taskDadoPorMesEPrioridade);
        }
    }
}
