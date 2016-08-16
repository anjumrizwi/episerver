using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerSimpleSite.Models.Blocks;
using EPiServerSimpleSite.Models.Entities;
using EPiServerSimpleSite.Models;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServerSimpleSite.Models.Forms;
using EPiServer.Globalization;

namespace EPiServerSimpleSite.Controllers
{
    /// <summary>
    /// http://world.episerver.com/blogs/team-oshyn/dates/2016/3/posting-forms-with-episerver-mvc/
    /// 
    /// </summary>
    public class RegisterBlockController : BaseFomBlockController<RegisterBlock>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPermanentLinkMapper _permanentLinkMapper;
        private const string SUCCESS_KEY = "formPosted";

        public RegisterBlockController(IContentLoader contentLoader, IPermanentLinkMapper permanentLinkMapper)
        {
            _contentLoader = contentLoader;
            _permanentLinkMapper = permanentLinkMapper;
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
        public virtual ActionResult Submit(RegisterBlockModel formModel, RegisterBlock block, PageData page)
        {
            var returnUrl = UrlResolver.Current.GetUrl(formModel.CurrentPageLink);

            if (ModelState.IsValid)
            {
                returnUrl = UriSupport.AddQueryString(returnUrl, SUCCESS_KEY, formModel.CurrentBlockLink.ID.ToString());
            }

            SaveModelState(formModel.CurrentBlockLink);

            return Redirect(returnUrl);
        }

        public ActionResult Success()
        {
            // Return the default view
            return View();
        }
    }
}
