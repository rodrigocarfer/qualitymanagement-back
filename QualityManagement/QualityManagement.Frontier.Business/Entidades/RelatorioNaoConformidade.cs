using System.Collections.Generic;

namespace QualityManagement.Frontier.Business.Entidades
{
    public class RelatorioNaoConformidade
    {
        public IEnumerable<QuantidadeNaoConformidadePorTipo> QuantidadeNaoConformidadePorTipo { get; set; }
        public IEnumerable<QuantidadeNaoConformidadePorPrioridade> QuantidadeNaoConformidadePorPrioridade { get; set; }
        public IEnumerable<QuantidadeNaoConformidadePorDataEPrioridade> QuantidadeNaoConformidadePorDataEPrioridade { get; set; }
    }
}
