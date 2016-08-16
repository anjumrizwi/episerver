using EPiServer.Core;

namespace EPiServerDemoSite.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : EPiPageData
    {
        T CurrentPage { get; }
        ILayoutModel Layout { get; set; }
        IContent Section { get; set; }
    }
}