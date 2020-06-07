using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace QualityManagement.Util.Configurations
{
    public class Configuration
    {
        #region Variables

        private static Configuration _configuration;

        public ConnectionStringsConfig ConnectionStrings { get; }
        #endregion

        private Configuration(IConfiguration config)
        {
            ConnectionStrings = new ConnectionStringsConfig(config);
        }

        public static Configuration Get => _configuration ?? (_configuration = GetCurrentConfigurations());

        private static Configuration GetCurrentConfigurations()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            string path = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                            .SetBasePath(path)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables();

            Configuration config = new Configuration(builder.Build());

            return config;
        }
    }
}
