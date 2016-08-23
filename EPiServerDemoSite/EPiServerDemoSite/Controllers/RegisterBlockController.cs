using EPiServer;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using EPiServerDemoSite.Models;
using EPiServerDemoSite.Models.Account;
using EPiServerDemoSite.Models.Blocks;
using EPiServerDemoSite.Models.Forms;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EPiServerDemoSite.Controllers
{
    /// <summary>
    /// http://world.episerver.com/blogs/team-oshyn/dates/2016/3/posting-forms-with-episerver-mvc/
    /// 
    /// </summary>
    public class RegisterBlockController : BaseFomBlockController<RegisterBlock>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPermanentLinkMapper _permanentLinkMapper;
        private ApplicationUserManager _userManager;

        private const string SUCCESS_KEY = "formPosted";

        public RegisterBlockController()
        {
            //_userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public RegisterBlockController(IContentLoader contentLoader, IPermanentLinkMapper permanentLinkMapper, ApplicationUserManager userManager)
        {
            _contentLoader = contentLoader;
            _permanentLinkMapper = permanentLinkMapper;
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public override ActionResult Index(RegisterBlock currentBlock)
        {
            var pageRouteHelper = ServiceLocator.Current.GetInstance<PageRouteHelper>();
            var currentBlockLink = ((IContent)currentBlock).ContentLink;

            LoadModelState(currentBlockLink);

            var model = new RegisterBlockModel
            {
                CurrentPageLink = pageRouteHelper.PageLink,
                CurrentBlockLink = currentBlockLink,
                CurrentLanguage = ContentLanguage.PreferredCulture.Name,
                ParentBlock = currentBlock
            };
            ContentReference postedBlock;

            if (ContentReference.TryParse(Request.QueryString[SUCCESS_KEY], out postedBlock) & postedBlock.CompareToIgnoreWorkID(currentBlockLink))
                return PartialView("Success");

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> Submit(RegisterBlockModel formModel, RegisterBlock block, PageData page)
        {
            var returnUrl = UrlResolver.Current.GetUrl(formModel.CurrentPageLink);

            if (ModelState.IsValid)
            {
                returnUrl = UriSupport.AddQueryString(returnUrl, SUCCESS_KEY, formModel.CurrentBlockLink.ID.ToString());
            }

            SaveModelState(formModel.CurrentBlockLink);

            return await Register(formModel);
        }

        public ActionResult Success()
        {
            // Return the default view
            return View();
        }

        private async Task<ActionResult> Register(RegisterBlockModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.EmailId
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.StatusMessage = "User Created!";
                    //return Redirect("/");
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            //return Json("Hello");
            return PartialView("Index", model);

            //return Content(ViewBag.StatusMessage);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
