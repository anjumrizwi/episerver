using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServerSimpleSite.Models.Pages;
using EPiServerSimpleSite.Models.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace EPiServerSimpleSite.Controllers
{
    /// <summary>
    /// http://world.episerver.com/blogs/Daniel-Ovaska/Dates/2016/6/creating-a-custom-login-page/
    /// </summary>
    public class LoginPageController : PageControllerBase<LoginPage>
    {
        public ActionResult Index(LoginPage currentPage, [FromUri]string ReturnUrl)
        {
            var model = new LoginModel(currentPage);
            model.LoginPostbackData.ReturnUrl = ReturnUrl;

            return View(model);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(LoginPage currentPage, [FromBody] LoginFormPostbackData LoginPostbackData)
        {
            var model = new LoginModel(currentPage);
            var isValid = Membership.Provider.ValidateUser(LoginPostbackData.Username, LoginPostbackData.Password);

            if (isValid)
            {
                var redirectUrl = GetRedirectUrl(LoginPostbackData.ReturnUrl);
                FormsAuthentication.SetAuthCookie(LoginPostbackData.Username, LoginPostbackData.RememberMe);
                return Redirect(redirectUrl); //Important to redirect after login to be sure cookies etc are set.
            }

            model.Message = "Wrong credentials, try again";

            return View("Index", model);
        }

        /// <summary>
        /// You can extend this to set redirect url to some property you set on login page in edit if you like
        /// Might also depend on role of user...
        /// </summary>
        public string GetRedirectUrl(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return returnUrl;
            }
            return FormsAuthentication.DefaultUrl;
        }
    }
}