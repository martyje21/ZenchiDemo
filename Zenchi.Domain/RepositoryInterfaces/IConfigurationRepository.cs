using Zenchi.Domain.Entities;
using System.Collections.Generic;

namespace Zenchi.Domain.RepositoryInterfaces
{
    public interface IConfigurationRepository
    {
        List<Configuration> GetConfigurations();
    }
}
