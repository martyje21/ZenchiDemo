
namespace Zenchi.WebApi
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Register the automapper mappings for domain to data entities in the repository
            new Zenchi.Repository.Ef.MappingUtility().RegisterMappings();
        }
    }
}