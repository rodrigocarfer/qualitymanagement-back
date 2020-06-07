using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Repository.Entidades
{
    public class QuantidadeNaoConformidadePorDataEPrioridadeEntidade
    {
        public DateTime DataOcorrencia { get; set; }
        public PrioridadeOcorrencia PrioridadeOcorrencia { get; set; }
        public int Quantidade { get; set; }
    }
}
