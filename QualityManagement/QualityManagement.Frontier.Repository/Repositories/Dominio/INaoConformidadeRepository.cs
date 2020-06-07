using System.Collections.Generic;
using System.Threading.Tasks;
using QualityManagement.Frontier.Repository.Entidades;

namespace QualityManagement.Frontier.Repository.Repositories.Dominio
{
    public interface INaoConformidadeRepository
    {
        void Registrar(NaoConformidadeEntidade naoConformidade);
        Task<IEnumerable<QuantidadeNaoConformidadePorTipoEntidade>> ObterDadoPorTipo();
        Task<IEnumerable<QuantidadeNaoConformidadePorPrioridadeEntidade>> ObterDadoPorPrioridade();
        Task<IEnumerable<QuantidadeNaoConformidadePorDataEPrioridadeEntidade>> ObterDadoPorMesEPrioridade();
    }
}