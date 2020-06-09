using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QualityManagement.Frontier.Repository.Entidades;
using QualityManagement.Frontier.Repository.Repositories.Dominio;
using QualityManagement.Util.Configurations;

namespace QualityManagement.Repository.Dominio
{
    public class NaoConformidadeRepository : BaseRepository<NaoConformidadeEntidade>, INaoConformidadeRepository
    {
        public NaoConformidadeRepository() : base(Configuration.Get.ConnectionStrings.GestaoQualidadeDb) { }

        private const string INSERT_NAO_CONFORMIDADE = @"
            INSERT INTO nao_conformidade 
            VALUES      
            (@tipo_ocorrencia, 
             @prioridade_ocorrencia, 
             @data_ocorrencia, 
             @data_inclusao, 
             @titulo_ocorrencia, 
             @descricao_ocorrencia) 
        ";

        private const string SELECT_OBTER_REGISTROS_RECENTES = @"
           SELECT TOP 10 
              data_inclusao         AS DataInclusao, 
              data_ocorrencia       AS DataOcorrencia, 
              descricao_ocorrencia  AS DescricaoOcorrencia, 
              prioridade_ocorrencia AS PrioridadeOcorrencia, 
              tipo_ocorrencia       AS TipoOcorrencia, 
              titulo_ocorrencia     AS TituloOcorrencia 
           FROM   nao_conformidade 
           ORDER BY data_inclusao DESC
        ";

        private const string SELECT_NAO_CONFORMIDADES_POR_TIPO = @"
           SELECT tipo_ocorrencia AS TipoOcorrencia, 
                   Count(1) AS Quantidade 
           FROM   nao_conformidade 
           GROUP  BY tipo_ocorrencia 
        ";

        private const string SELECT_NAO_CONFORMIDADES_POR_PRIORIDADE = @"
            SELECT prioridade_ocorrencia AS PrioridadeOcorrencia, 
                   Count(1) AS Quantidade 
           FROM   nao_conformidade 
           GROUP  BY prioridade_ocorrencia           
        ";

        private const string SELECT_NAO_CONFORMIDADES_POR_DATA_E_PRIORIDADE = @"
           SELECT AnoMes, 
                   (SELECT Count(1) 
                    FROM   nao_conformidade 
                    WHERE  CONVERT(VARCHAR(7), data_ocorrencia, 126) = anomes 
                           AND prioridade_ocorrencia = 0) QuantidadeBaixa, 
                   (SELECT Count(1) 
                    FROM   nao_conformidade 
                    WHERE  CONVERT(VARCHAR(7), data_ocorrencia, 126) = anomes 
                           AND prioridade_ocorrencia = 1) QuantidadeMedia, 
                   (SELECT Count(1) 
                    FROM   nao_conformidade 
                    WHERE  CONVERT(VARCHAR(7), data_ocorrencia, 126) = anomes 
                           AND prioridade_ocorrencia = 2) QuantidadeAlta 
            FROM   (SELECT CONVERT(VARCHAR(7), data_ocorrencia, 126) AS AnoMes 
                    FROM   nao_conformidade) dadosRelatorio 
            GROUP  BY anomes 
        ";

        public void Registrar(NaoConformidadeEntidade naoConformidadeEntidade)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add("@tipo_ocorrencia", naoConformidadeEntidade.TipoOcorrencia, System.Data.DbType.Int32);
            parametros.Add("@prioridade_ocorrencia", naoConformidadeEntidade.PrioridadeOcorrencia,
                System.Data.DbType.Int32);
            parametros.Add("@data_ocorrencia", naoConformidadeEntidade.DataOcorrencia, System.Data.DbType.DateTime);
            parametros.Add("@data_inclusao", DateTime.Now, System.Data.DbType.DateTime);
            parametros.Add("@titulo_ocorrencia", naoConformidadeEntidade.TituloOcorrencia, System.Data.DbType.String);
            parametros.Add("@descricao_ocorrencia", naoConformidadeEntidade.DescricaoOcorrencia,
                System.Data.DbType.String);

            Execute(INSERT_NAO_CONFORMIDADE, parametros);
        }

        public Task<IEnumerable<NaoConformidadeEntidade>> ObterRegistrosRecentes()
        {
            return ListAsync<NaoConformidadeEntidade>(SELECT_OBTER_REGISTROS_RECENTES);
        }

        public Task<IEnumerable<QuantidadeNaoConformidadePorTipoEntidade>> ObterDadoPorTipo()
        {
            return ListAsync<QuantidadeNaoConformidadePorTipoEntidade>(SELECT_NAO_CONFORMIDADES_POR_TIPO);
        }

        public Task<IEnumerable<QuantidadeNaoConformidadePorPrioridadeEntidade>> ObterDadoPorPrioridade()
        {
            return ListAsync<QuantidadeNaoConformidadePorPrioridadeEntidade>(SELECT_NAO_CONFORMIDADES_POR_PRIORIDADE);
        }

        public Task<IEnumerable<QuantidadeNaoConformidadePorDataEPrioridadeEntidade>> ObterDadoPorMesEPrioridade()
        {
            return ListAsync<QuantidadeNaoConformidadePorDataEPrioridadeEntidade>(SELECT_NAO_CONFORMIDADES_POR_DATA_E_PRIORIDADE);
        }
    }
}
