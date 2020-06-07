using System.Threading.Tasks;
using QualityManagement.Frontier.Business.Business.Dominio;
using QualityManagement.Frontier.Business.Entidades;
using QualityManagement.Frontier.Business.Service.Dominio;

namespace QualityManagement.Business.Dominio
{
    public class NaoConformidadeBusiness : INaoConformidadeBusiness
    {
        private readonly INaoConformidadeService _naoConformidadeService;

        public NaoConformidadeBusiness(INaoConformidadeService naoConformidadeService)
        {
            _naoConformidadeService = naoConformidadeService;
        }

        public void Registrar(NaoConformidade naoConformidade)
        {
            _naoConformidadeService.Registrar(naoConformidade);
        }

        public Task<RelatorioNaoConformidade> ObterDadosRelatorio()
        {
            return _naoConformidadeService.ObterDadosRelatorio();
        }
    }
}