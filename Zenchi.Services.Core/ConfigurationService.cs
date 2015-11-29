using Zenchi.Domain.Entities;
using Zenchi.Domain.RepositoryInterfaces;
using Zenchi.Domain.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenchi.Services.Core
{
    public class ConfigurationService : IConfigurationService
    {

        const string CACHE_CONFIGURATIONS = "Configurations";
        const string CONFIG_CACHE_EXPIRATION_MINUTES = "CacheExpirationMinutes";
        const string CONFIG_OAUTH_LOGIN_URL = "OAuthLoginUrl";
        const string CONFIG_OAUTH_LOGOUT_URL = "OAuthLogoutUrl";
        const string CONFIG_OAUTH_REGISTER_URL = "OAuthRegisterUrl";
        const string CONFIG_ZENCHI_WEB_API_URL = "ZenchiWebApiUrl";

        private ICacheService CacheService { get; set; }
        
        public ConfigurationService(IConfigurationRepository configurationRepo, ICacheService cacheService)
        {         
            if (configurationRepo == null)
                throw new ArgumentNullException("IConfigurationRepository is null");

            if (cacheService == null)
                throw new ArgumentNullException("ICacheInterface is null");

            ConfigurationRepository = configurationRepo;
            CacheService = cacheService;
        }


        public string CookieUrl
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["AuthCookieDomain"]; }
        }

        public string OAuthLoginUrl
        {
            get { return GetStringValue(CONFIG_OAUTH_LOGIN_URL); }
        }

        public string OAuthLogoutUrl
        {
            get { return GetStringValue(CONFIG_OAUTH_LOGOUT_URL); }
        }

        public string OAuthRegisterUrl
        {
            get { return GetStringValue(CONFIG_OAUTH_REGISTER_URL); }
        }

        public string ZenchiWebApiUrl
        {
            get { return GetStringValue(CONFIG_ZENCHI_WEB_API_URL); }
        }


        private List<Configuration> Configurations
        {
            get
            {
                // Cache configurations
                var configurations = CacheService.Get(CACHE_CONFIGURATIONS); 
                if (configurations == null)
                {
                    configurations = GetConfigurationList();
                    double cacheMinutes = GetDoubleValue(configurations as List<Configuration>, CONFIG_CACHE_EXPIRATION_MINUTES);
                    CacheService.Insert(CACHE_CONFIGURATIONS, configurations, DateTime.Now.AddMinutes(cacheMinutes));
                }

                return ((List<Configuration>)configurations);
            }
        }

        private List<Configuration> GetConfigurationList()
        {
            return ConfigurationRepository.GetConfigurations();
        }

        private IConfigurationRepository ConfigurationRepository { get; set; }

        private string GetStringValue(string key)
        {
            string value = String.Empty;

            Configuration configuration = Configurations.FirstOrDefault(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (configuration != null)
            {
                value = configuration.Value;
            }

            return value;
        }

        private double GetDoubleValue(string key)
        {
            double value = 0;

            Configuration configuration = Configurations.FirstOrDefault(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (configuration != null)
            {
                double.TryParse(configuration.Value, out value);
            }

            return value;
        }

        private double GetDoubleValue(List<Configuration> configurations, string key)
        {
            double value = 0;

            Configuration configuration = configurations.FirstOrDefault(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (configuration != null)
            {
                double.TryParse(configuration.Value, out value);
            }

            return value;
        }

        private int GetIntegerValue(string key)
        {
            int value = 0;

            Configuration configuration = Configurations.FirstOrDefault(x => x.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));
            if (configuration != null)
            {
                int.TryParse(configuration.Value, out value);
            }

            return value;
        }

 
    }
}
