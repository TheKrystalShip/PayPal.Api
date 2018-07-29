using Microsoft.Extensions.Configuration;

using System.IO;

namespace TheKrystalShip.PayPal.Api.Properties
{
    public class Settings
    {
        private static IConfiguration _config;

        public static IConfiguration Instance
        {
            get
            {
                if (_config != null)
                    return _config;

                return _config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Path.Combine("Properties", "settings.json"), false, true)
                    .Build();
            }
        }
    }
}
