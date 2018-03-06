using System.IO;
using Microsoft.Extensions.Configuration;

namespace UtilityFramework.Data.Repository
{
    public static class AppSettingsBase
    {
        private static IConfigurationRoot Configuration { get; set; }

        public static BaseSettings GetSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var baseSettings = Configuration.GetSection("DATABASE").Get<BaseSettings>();

            return baseSettings;
        }


    }
}