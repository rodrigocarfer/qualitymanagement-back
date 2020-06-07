using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Repository.Entidades
{
    public class NaoConformidadeEntidade
    {
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public PrioridadeOcorrencia PrioridadeOcorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string TituloOcorrencia { get; set; }
        public string DescricaoOcorrencia { get; set; }
    }
}
