using System;
using QualityManagement.Util.Enumerators;

namespace QualityManagement.Frontier.Repository.Entidades
{
    public class NaoConformidadeEntidade
    {
        public int TipoOcorrencia { get; set; }
        public int PrioridadeOcorrencia { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime DataInclusao { get; set; }
        public string TituloOcorrencia { get; set; }
        public string DescricaoOcorrencia { get; set; }
    }
}
