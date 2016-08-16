using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServerDemoSite.Models.Pages;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Controllers
{
    public class TwoColumnPageController : PageControllerBase<TwoColumnPage>
    {
        public ActionResult Index(TwoColumnPage currentPage)
        {
            var model = CreateModel(currentPage);
            var startPageContentLink = ContentReference.StartPage;
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = contentLoader.Get<HomePage>(startPageContentLink);

            model.Layout = (ILayoutModel)startPage;

            return View(model);
        }

        /// <summary>
        /// Creates a PageViewModel where the type parameter is the type of the page.
        /// </summary>
        /// <remarks>
        /// Used to create models of a specific type without the calling method having to know that type.
        /// </remarks>
        private static IPageViewModel<TwoColumnPage> CreateModel(TwoColumnPage page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<TwoColumnPage>;
        }
    }
}