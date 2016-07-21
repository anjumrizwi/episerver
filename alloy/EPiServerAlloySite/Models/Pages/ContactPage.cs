using System.ComponentModel.DataAnnotations;
using EPiServerAlloySite.Business;
using EPiServerAlloySite.Business.EditorDescriptors;
using EPiServerAlloySite.Business.Rendering;
using EPiServer.Web;
using EPiServer.Core;

namespace EPiServerAlloySite.Models.Pages
{
    /// <summary>
    /// Represents contact details for a contact person
    /// </summary>
    [SiteContentType(
        GUID = "F8D47655-7B50-4319-8646-3369BA9AF05B",
        GroupName = Global.GroupNames.Specialized)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-contact.png")]
    public class ContactPage : SitePageData, IContainerPage
    {
        [Display(GroupName = Global.GroupNames.Contact)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = Global.GroupNames.Contact)]
        public virtual string Phone { get; set; }
        
        [Display(GroupName = Global.GroupNames.Contact)]
        [Business.EmailAddress]
        public virtual string Email { get; set; }
    }
}