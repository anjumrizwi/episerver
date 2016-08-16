using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerDemoSite.Models.Media;

namespace EPiServerDemoSite.Models.Pages
{
    [ContentType(DisplayName = "CarousalPage", GUID = "814631e5-66ba-4624-81e6-39c8a16195c5", Description = "")]
    public class CarousalPage : EPiPageData
    {
        [CultureSpecific]
        [Display(
            Name = "Featured Content",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [AllowedTypes(typeof(ImageFile))]
        public virtual ContentArea FeaturedContentArea { get; set; }
    }
}