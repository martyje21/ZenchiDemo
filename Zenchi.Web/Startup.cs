using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(Zenchi.Web.Startup))]
namespace Zenchi.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                CookieName = "Zenchi.OAuth",
                CookieDomain = ConfigurationManager.AppSettings["AuthCookieDomain"],
                LoginPath = new PathString("/Home/Login")
            });
        }
    }
}