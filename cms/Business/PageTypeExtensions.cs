using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerSimpleSite.Business
{
    /// <summary>
    /// Provides extension methods for types intended to be used when working with page types
    /// </summary>
    public static class PageTypeExtensions
    {
        /// <summary>
        /// Returns the definition for a specific page type
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public static PageType GetPageType(this Type pageType)
        {
            var pageTypeRepository = ServiceLocator.Current.GetInstance<PageTypeRepository>();

            return pageTypeRepository.Load(pageType);
        }
    }
}