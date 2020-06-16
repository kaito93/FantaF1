using System.Configuration;

namespace FantaF1
{
    public static class AppSettingsConfiguration
    {

        public static string PathFileCsv => ConfigurationManager.AppSettings["PathCSV"];

    }
}