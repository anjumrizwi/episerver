using EPiServer.Core;
using EPiServerDemoSite.Models.Pages;

namespace EPiServerDemoSite.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : EPiPageData
    {
        public virtual ContentReference HomeVideo { get; set; }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; private set; }
        public ILayoutModel Layout { get; set; }
        public IContent Section { get; set; }
    }

    public static class PageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static PageViewModel<T> Create<T>(T page) where T : HomePage
        {
            return new PageViewModel<T>(page);
        }
    }
}