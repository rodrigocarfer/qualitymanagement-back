using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Business.Entidades
{
    public class QuantidadeNaoConformidadePorDataEPrioridade
    {
        public DateTime AnoMes { get; set; }
        public int QuantidadeBaixa { get; set; }
        public int QuantidadeMedia { get; set; }
        public int QuantidadeAlta { get; set; }
    }
}
