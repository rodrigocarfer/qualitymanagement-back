using System.Collections.Generic;

namespace QualityManagement.Frontier.Business.Entidades
{
    public class RelatorioNaoConformidade
    {
        public IEnumerable<NaoConformidade> RegistrosRecentes { get; set; }
        public IEnumerable<QuantidadeNaoConformidadePorTipo> QuantidadeNaoConformidadePorTipo { get; set; }
        public IEnumerable<QuantidadeNaoConformidadePorPrioridade> QuantidadeNaoConformidadePorPrioridade { get; set; }
        public IEnumerable<QuantidadeNaoConformidadePorDataEPrioridade> QuantidadeNaoConformidadePorDataEPrioridade { get; set; }
    }
}
