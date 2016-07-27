using EPiServer.Core;
using EPiServerSimpleSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPiServerSimpleSite.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        LayoutModel Layout { get; set; }
        IContent Section { get; set; }
    }
}
