using Moq;
using System;
using System.Threading.Tasks;
using AutoMapper;
using QualityManagement.Business.Dominio;
using QualityManagement.Frontier.Business.Entidades;
using QualityManagement.Frontier.Business.Service.Dominio;
using QualityManagement.Tests.Util;
using Xunit;
using Assert = Xunit.Assert;
using QualityManagement.Frontier.Business.Business.Dominio;
using QualityManagement.Map.InjecaoDependencias;

namespace QualityManagement.Tests.Dominio
{
    public class EntidadeTests
    {
        private IMapper _mapper;
        private INaoConformidadeBusiness _entidadeBusiness;
        private Mock<IEntidadeService> _entidadeService;

        private void InitializeTest()
        {
            _mapper = InjecaoDependencias.CriarMapperProfiles();

            _entidadeService = new Mock<IEntidadeService>();

            _entidadeService.Setup(x => x.MetodoSemConversoes(
                It.IsAny<DateTime>())).ReturnsAsync(GetMockDataEntidade());

            _entidadeBusiness = new EntidadeBusiness(_entidadeService.Object);
        }

        #region Mock Data
        private Model GetMockDataEntidade()
        {
            return new Model()
            {
                Dado1 = "Dado 1 Do Banco",
                Dado2 = "Dado 2 Do Banco"
            };
        }

        #endregion

        [Theory]
        [InlineData(1, 1)]
        public async Task TestarMetodo(int ano, int mes)
        {
            InitializeTest();

            Model modelo = await _entidadeBusiness.Metodo(ano, mes);

            Assert.NotNull(modelo);
            Assert.True(TestsHelper.VerificarEntidadesIguais(GetMockDataEntidade(), modelo));
        }
    }
}

