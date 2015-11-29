using Zenchi.Domain.Entities;
using Zenchi.Domain.RepositoryInterfaces;
using Zenchi.Repository.Ef.DataEntities;
using System.Collections.Generic;
using System.Linq;

namespace Zenchi.Repository.Ef
{
    public class ConfigurationRepository : BaseRepository, IConfigurationRepository
    {
        public List<Configuration> GetConfigurations()
        {
            List<Configuration> configurations = new List<Configuration>();
            using (var db = new ZenchiDBContext())
            {
                var query = from ac in db.ConfigurationData
                            select ac;

                foreach (ConfigurationData configurationData in query.ToList<ConfigurationData>())
                {
                    configurations.Add(Mapper.MapConfiguration(configurationData));
                }
            }
            return configurations;
        }
    }
}
