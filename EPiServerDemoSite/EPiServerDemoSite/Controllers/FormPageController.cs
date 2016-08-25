using EPiServer;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServerDemoSite.Models.Blocks;
using EPiServerDemoSite.Models.Entities;
using EPiServerDemoSite.Models.Pages;
using EPiServerDemoSite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPiServerDemoSite.Controllers
{
    public class FormPageController : PageControllerBase<FormPage>
    {
        public ActionResult Index(FormPage currentPage)
        {
            var model = new FormPageModel(currentPage);

            return View("Index", model);
        }

        public ActionResult Save(FormPage currentPage, PostalAddress address)
        {
            if (currentPage.RelatedContentArea != null || currentPage.RelatedContentArea.Items.Any())
            {
                var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

                foreach (var item in currentPage.RelatedContentArea.Items)
                {
                    var shippingBlock = contentLoader.Get<PostalAddressBlock>(item.ContentLink);

                    if (shippingBlock != null)
                    {
                        shippingBlock.Address = address;

                        var pageId = ((EPiServer.Core.PageData)(currentPage)).ContentLink.ID;

                        switch (pageId)
                        {
                            case 1066:
                                //TODO Save data for Delivery Address
                                ViewBag.Message = "Your postal Delivery address successfully saved.";
                                break;
                            case 1067:
                                ViewBag.Message = "Your postal Billing address successfully saved.";
                                //TODO Save data for Billing address
                                break;
                            default:
                                break;
                        }

                        
                    }
                }
            }

            var model = new FormPageModel(currentPage);

            return View("Index", model);
        }
    }
}