using System.Threading.Tasks;
using QualityManagement.Frontier.Business.Entidades;

namespace QualityManagement.Frontier.Business.Business.Dominio
{
    public interface INaoConformidadeBusiness
    {
        void Registrar(NaoConformidade naoConformidade);
        Task<RelatorioNaoConformidade> ObterDadosRelatorio();
    }
}