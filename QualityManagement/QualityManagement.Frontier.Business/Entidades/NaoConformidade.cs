using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Business.Entidades
{
    public class NaoConformidade
    {
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public PrioridadeOcorrencia PrioridadeOcorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string TituloOcorrencia { get; set; }
        public string DescricaoOcorrencia { get; set; }
    }
}
