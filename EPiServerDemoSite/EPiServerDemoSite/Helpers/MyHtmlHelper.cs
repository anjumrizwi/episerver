using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServerDemoSite.Models;
using EPiServerDemoSite.Models.Media;

namespace EPiServerDemoSite.Helpers
{
    public static class MyHtmlHelper
    {
        public static MvcHtmlString CreateMenu(this HtmlHelper helper)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var pages = contentLoader.GetChildren<EPiPageData>(ContentReference.StartPage);

            if (pages == null) return MvcHtmlString.Empty;

            var template = GetDefaultItemTemplate(helper);
            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);

            foreach (var page in pages)
            {
                template(page).WriteTo(writer);
            }

            return new MvcHtmlString(buffer.ToString());
        }

        public static MvcHtmlString CreateChildMenu(this HtmlHelper helper, ContentReference currentContentLink)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var pages = contentLoader.GetChildren<EPiPageData>(currentContentLink);

            if (pages == null) return MvcHtmlString.Empty;

            var template = GetDefaultItemTemplate(helper);
            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);

            foreach (var page in pages)
            {
                template(page).WriteTo(writer);
            }

            return new MvcHtmlString(buffer.ToString());
        }

        public static MvcHtmlString CreateBreadcrumbsMenu(this HtmlHelper helper, ContentReference currentContentLink)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var pages = contentLoader.GetAncestors(currentContentLink)
               .Reverse()
               .Select(x => x.ContentLink)
               .SkipWhile(x => x.ID < ContentReference.StartPage.ID)
               .ToList();
            pages.Add(currentContentLink);


            var template = GetMenuItemTemplate(helper);
            var buffer = new StringBuilder();
            var writer = new StringWriter(buffer);

            foreach (var page in pages)
            {
                template(page).WriteTo(writer);
            }

            return new MvcHtmlString(buffer.ToString());
        }

        private static Func<PageData, HelperResult> GetDefaultItemTemplate(HtmlHelper helper)
        {
            return x => new HelperResult(writer => writer.Write(string.Format("<li>{0}</li>", helper.PageLink(x).ToHtmlString())));
        }

        private static Func<ContentReference, HelperResult> GetMenuItemTemplate(HtmlHelper helper)
        {
            return x => new HelperResult(writer => writer.Write(string.Format("<li> {0} &gt;</li>", helper.PageLink(x.ToPageReference()).ToHtmlString())));
        }

        public static IEnumerable<T> GetContentItems<T>(this IEnumerable<ContentAreaItem> contentAreaItems, LanguageLoaderOption languageLoaderOption = null, IContentLoader contentLoader = null) where T : IContent
        {
            if (contentAreaItems == null)
            {
                return Enumerable.Empty<T>();
            }

            if (contentLoader == null)
            {
                contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            }

            if (languageLoaderOption == null)
            {
                languageLoaderOption = LanguageLoaderOption.FallbackWithMaster();
            }

            return contentLoader.GetItems(contentAreaItems.Select(i => i.ContentLink), new LoaderOptions { languageLoaderOption }).OfType<T>();
        }

        public static List<ImageFile> GetImages(ContentReference folder)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            return contentRepository.GetChildren<ImageFile>(folder).ToList();
        }

        public static List<VideoFile> GetVideos(ContentReference folder)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            return contentRepository.GetChildren<VideoFile>(folder).ToList();
        }

    }
}