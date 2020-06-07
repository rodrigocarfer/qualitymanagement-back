using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QualityManagement.Business.Dominio;
using QualityManagement.Frontier.Business.Business.Dominio;
using QualityManagement.Frontier.Business.Service.Dominio;
using QualityManagement.Frontier.Repository.Repositories.Dominio;
using QualityManagement.Map.Mapper.Profiles;
using QualityManagement.Repository.Dominio;
using QualityManagement.Service.Dominio;

namespace QualityManagement.Map.InjecaoDependencias
{
    public static class InjecaoDependencias
    {
        public static void Configurar(IServiceCollection services)
        {
            #region Mapeamento Business

            services.AddTransient<INaoConformidadeBusiness, NaoConformidadeBusiness>();

            #endregion

            #region Mapeamento Service

            services.AddTransient<INaoConformidadeService, NaoConformidadeService>();

            #endregion

            #region Mapeamento Repository

            services.AddTransient<INaoConformidadeRepository, NaoConformidadeRepository>();

            #endregion

            #region Mappers

            services.AddSingleton(CriarMapperProfiles());

            # endregion
        }
        public static IMapper CriarMapperProfiles()
        {
            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<EntidadeBusinessMapper>();
            });

            return mappingConfig.CreateMapper();
        }
    }
}