using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Models.Pages
{
    [ContentType(DisplayName = "TwoColumnPage", GUID = "898b6aad-fed4-4496-9c35-c64aa6cbd647", Description = "")]
    public class TwoColumnPage : EPiPageData, IHasRelatedContent
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 310)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(IContentData) })]
        public virtual ContentArea RelatedContentArea { get; set; }
    }
}