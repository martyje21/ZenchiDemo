using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace Zenchi.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            ClaimsPrincipal user = System.Security.Claims.ClaimsPrincipal.Current;
            var tokenClaim = user.Claims.FirstOrDefault(c => c.Type == "bearer_token");
            if (tokenClaim != null)
            {
                ViewBag.Token = tokenClaim.Value;
            }

            return View();
        }

        public ActionResult Login()
        {
            return Redirect("https://zenchioauth.martydev.com/login?url=https://zenchiweb.martydev.com");
        }
    }
}