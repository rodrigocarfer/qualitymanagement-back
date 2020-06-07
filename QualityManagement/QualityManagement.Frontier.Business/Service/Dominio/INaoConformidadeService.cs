using System.Threading.Tasks;
using QualityManagement.Frontier.Business.Entidades;

namespace QualityManagement.Frontier.Business.Service.Dominio
{
    public interface INaoConformidadeService
    {
        void Registrar(NaoConformidade naoConformidade);
        Task<RelatorioNaoConformidade> ObterDadosRelatorio();
    }
}
