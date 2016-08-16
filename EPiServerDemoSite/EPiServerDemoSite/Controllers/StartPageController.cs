using System.Web.Mvc;
using EPiServerDemoSite.Models.Pages;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Controllers
{
    public class StartPageController : PageControllerBase<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */
           //if(SiteDefinition.Current.StartPage == null || SiteDefinition.Current.StartPage.ID ==0) SiteDefinition.Current.StartPage = currentPage.ContentLink;
           var model = PageViewModel.Create(currentPage);
            model.Layout = (ILayoutModel)currentPage;
            return View(model);
        }
    }
}