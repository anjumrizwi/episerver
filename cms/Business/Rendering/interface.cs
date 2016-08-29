using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerSimpleSite.Business.Rendering
{
    /// <summary>
    /// Defines a property for CSS class(es) which will be added to the class
    /// attribute of containing elements when rendered in a content area with a size tag.
    /// </summary>
    interface ICustomCssInContentArea
    {
        string ContentAreaCssClass { get; }
    }

    /// <summary>
    /// Marker interface for content types which should not be handled by DefaultPageController.
    /// </summary>
    interface IContainerPage
    {
    }
}