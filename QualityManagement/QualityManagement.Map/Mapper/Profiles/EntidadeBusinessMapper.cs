using AutoMapper;
using QualityManagement.Frontier.Business.Entidades;
using QualityManagement.Frontier.Repository.Entidades;

namespace QualityManagement.Map.Mapper.Profiles
{
    public class EntidadeBusinessMapper : Profile
    {
        public EntidadeBusinessMapper()
        {
            #region ModelEntity Para Model

            CreateMap<NaoConformidadeEntidade, NaoConformidade>();
            CreateMap<NaoConformidade, NaoConformidadeEntidade>();

            CreateMap<QuantidadeNaoConformidadePorTipoEntidade, QuantidadeNaoConformidadePorTipo>();
            CreateMap<QuantidadeNaoConformidadePorPrioridadeEntidade, QuantidadeNaoConformidadePorPrioridade>();
            CreateMap<QuantidadeNaoConformidadePorDataEPrioridadeEntidade, QuantidadeNaoConformidadePorDataEPrioridade>();

            #endregion
        }
    }
}
