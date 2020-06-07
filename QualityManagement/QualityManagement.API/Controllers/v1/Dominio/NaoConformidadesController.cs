using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QualityManagement.API.Filters;
using QualityManagement.Frontier.Business.Entidades;
using QualityManagement.Frontier.Business.Business.Dominio;

namespace QualityManagement.API.Controllers.v1.Dominio
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    [ApiController]
    [ApplicationTokenFilter]
    public class NaoConformidadesController : ControllerBase
    {
        private readonly INaoConformidadeBusiness _naoConformidadeBusiness;

        public NaoConformidadesController(INaoConformidadeBusiness naoConformidadeBusiness)
        {
            _naoConformidadeBusiness = naoConformidadeBusiness;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("nao-conformidades")]
        public IActionResult RegistrarOcorrenciaNaoConformidade(NaoConformidade requisicao)
        {
            _naoConformidadeBusiness.Registrar(requisicao);
            return Ok();
        }

        [ProducesResponseType(typeof(RelatorioNaoConformidade), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("nao-conformidades/relatorio")]
        public async Task<IActionResult> ObterRelatorioNaoConformidades()
        {
            return Ok(await _naoConformidadeBusiness.ObterDadosRelatorio());
        }
    }
}