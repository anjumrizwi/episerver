using System;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServerDemoSite.Models.Pages;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Controllers
{
    public class CarousalPageController : PageControllerBase<CarousalPage>
    {
        public ActionResult Index(CarousalPage currentPage)
        {
            var model = CreateModel(currentPage);
            var startPageContentLink = ContentReference.StartPage;
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var startPage = contentLoader.Get<HomePage>(startPageContentLink);

            //var images = contentLoader.GetChildren<ImageFile>(SiteDefinition.Current.GlobalAssetsRoot);

            model.Layout = startPage;

            return View(model);
        }

        /// <summary>
        /// Creates a PageViewModel where the type parameter is the type of the page.
        /// </summary>
        /// <remarks>
        /// Used to create models of a specific type without the calling method having to know that type.
        /// </remarks>
        private static IPageViewModel<CarousalPage> CreateModel(CarousalPage page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<CarousalPage>;
        }
    }
}