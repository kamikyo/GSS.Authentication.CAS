using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace OwinSample.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/ExternalLoginFailure
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string scheme)
        {
            if (string.IsNullOrWhiteSpace(scheme))
            {
                return View();
            }
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") };
            AuthenticationManager.Challenge(properties, scheme);
            return new EmptyResult();
        }

        // GET: /Account/Logout
        [HttpGet]
        public void Logout()
        {
            AuthenticationManager.SignOut(new AuthenticationProperties { RedirectUri = "/" });
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
    }
}