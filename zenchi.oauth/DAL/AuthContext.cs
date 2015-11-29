using Microsoft.AspNet.Identity.EntityFramework;

namespace Zenchi.OAuth.DAL
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}