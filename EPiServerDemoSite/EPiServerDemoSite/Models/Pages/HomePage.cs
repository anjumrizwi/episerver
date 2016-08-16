using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServerDemoSite.Models.Media;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "04713986-4bb5-4592-afa7-1b4d91cc6dec", Description = "")]
    [SiteImageUrl("~/Static/gfx/leader2.png")]
    [AvailableContentTypes(
        Availability.All,
        Include = new[] { typeof(StandardPage), typeof(ContentFolder) }, // Pages we can create under the start page...
        ExcludeOn = new[] { typeof(StandardPage), typeof(ContentFolder) })] 
    public class HomePage : EPiPageData, ILayoutModel
    {
        #region Layout Properties

        public virtual XhtmlString Footer { get; set; }

        public virtual XhtmlString Header { get; set; }

        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [UIHint(UIHint.Image)]
        [Display(
        Name = "Logo Image",
        GroupName = SystemTabNames.Content,
        Order = 40)]
        public virtual ContentReference Logo { get; set; }
        #endregion
    }
}