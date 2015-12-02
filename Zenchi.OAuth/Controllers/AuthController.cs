using Zenchi.OAuth.DAL;
using Zenchi.OAuth.DAL.Entities;
using Zenchi.OAuth.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Zenchi.OAuth.Controllers
{
    public class AuthController : Controller
    {
        private AuthRepository _repo = null;

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }


        public AuthController()
        {
            _repo = new AuthRepository();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel user)
        {
            AuthUser authUser = await ValidateLogin(user);
            if (authUser != null)
            {
                IdentitySignin(authUser);

                if(user.RedirectUrl != null)
                    return new RedirectResult(user.RedirectUrl);
            }
            else
            {
                ViewBag.Error = "Invalid Username or Password";
            }

            return View();
        }

        public ActionResult Login(string url)
        {
            ViewBag.RedirectUrl = url;

            return View();
        }

        public ActionResult Logout(string url)
        {
            IdentitySignout();

            if(String.IsNullOrEmpty(url))
            {
                return RedirectToAction("Login");
            }

            return new RedirectResult(url);
        }

        public ActionResult Register(string url)
        {
            ViewBag.RedirectUrl = url;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel user)
        {
           
            if (ModelState.IsValid)
            {
                RegisterUser userModel = new RegisterUser()
                {
                    UserName = user.UserName,
                    Password = user.Password
                };


                IdentityResult result = await _repo.RegisterUser(userModel);

                if(user.RedirectUrl != null)
                    return new RedirectResult(user.RedirectUrl);

            }

            return View();
        }


        [Authorize]
        public ActionResult TokenFromCookie()
        {
            
            var userName = ClaimsPrincipal.Current.Identity.GetUserName();
            var token = ClaimsPrincipal.Current.Claims.FirstOrDefault(c => c.Type == "bearer_token");

            return Json(token.Value, JsonRequestBehavior.AllowGet);
        }

        protected async Task<AuthUser> ValidateLogin(UserLoginModel userLogin)
        {
            IdentityUser user =  await _repo.FindUser(userLogin.UserName, userLogin.Password);

            if (user == null)
                return null;

            AuthUser authUser = new AuthUser()
            {
                UserId = user.Id,
                UserName = user.UserName
            };

            return authUser;
        }

        protected void IdentitySignin(AuthUser appUser, string providerKey = null, bool isPersistent = false)
        {
            // Setup issued and expired times
            DateTime issuedUTC = DateTime.UtcNow;
            DateTime expiredUTC = issuedUTC.AddDays(1);

            // create required claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.UserId));
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));

            // Create a bearer token for app to use for webapi calls
            string token = CreateBearerToken(claims, issuedUTC, expiredUTC);
            claims.Add(new Claim("bearer_token", token));

            // Create the identity stored in the cookie that will include the bearer_token
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaims(claims);

            AuthenticationManager.SignIn(new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = isPersistent,
                ExpiresUtc = expiredUTC,
                IssuedUtc = issuedUTC
            }, identity);
        }

        protected string CreateBearerToken(List<Claim> claims,DateTime issuedUTC,DateTime expiredUTC)
        {
            var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
            identity.AddClaims(claims);

            var ticket = new AuthenticationTicket(identity, new AuthenticationProperties()
            {
                ExpiresUtc = expiredUTC,
                IssuedUtc = issuedUTC
            });

            var token = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            return token;
        }

        protected void IdentitySignout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie,
                                            DefaultAuthenticationTypes.ExternalCookie);
        }


    }
}