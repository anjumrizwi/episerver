using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EPiServerDemoSite.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "6d7eb3c4-1898-4e29-bec0-3beda587d2f9", Description = "")]
    [SiteImageUrl("~/Static/gfx/fallows-media-wide.jpg")]
    public class StandardPage : EPiPageData
    {
        [Display(GroupName = SystemTabNames.Content, Order = 310)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(IContentData) })]
        public virtual ContentArea MainContentArea { get; set; }
    }
}