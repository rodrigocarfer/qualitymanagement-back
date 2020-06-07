using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Business.Entidades
{
    public class QuantidadeNaoConformidadePorDataEPrioridade
    {
        public DateTime DataOcorrencia { get; set; }
        public PrioridadeOcorrencia PrioridadeOcorrencia { get; set; }
        public int Quantidade { get; set; }
    }
}
