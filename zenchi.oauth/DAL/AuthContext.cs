using Microsoft.AspNet.Identity.EntityFramework;

namespace Zenchi.OAuth.DAL
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

        public static AuthContext Create()
        {
            return new AuthContext();
        }

        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}