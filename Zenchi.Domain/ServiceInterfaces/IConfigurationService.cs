using Zenchi.Domain.Entities;

namespace Zenchi.Domain.ServiceInterfaces
{
    public interface IConfigurationService
    {

        string OAuthLoginUrl { get; }

        string OAuthLogoutUrl { get; }

        string OAuthRegisterUrl { get; }

        string ZenchiWebApiUrl { get; }

    }
}
