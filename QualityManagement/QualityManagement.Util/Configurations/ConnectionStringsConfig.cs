using Microsoft.Extensions.Configuration;

namespace QualityManagement.Util.Configurations
{
    public class ConnectionStringsConfig
    {
        public string GestaoQualidadeDb { get; }

        public ConnectionStringsConfig(IConfiguration configuration)
        {
            GestaoQualidadeDb = configuration.GetConnectionString(Constants.UtilConstants.GESTAO_QUALIDADE_CONFIG);
        }

        public string Get(string connectionStringKey)
        {
            if (string.IsNullOrEmpty(connectionStringKey))
                return string.Empty;

            switch (connectionStringKey.Trim())
            {
                case Constants.UtilConstants.GESTAO_QUALIDADE_CONFIG:
                    return GestaoQualidadeDb;
                default:
                    return string.Empty;
            }
        }
    }
}
