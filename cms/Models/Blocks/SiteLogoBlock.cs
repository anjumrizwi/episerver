using EPiServer;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace EPiServerSimpleSite.Models.Blocks
{
    /// <summary>
    /// Used to provide a composite property on the start page to set site logotype settings
    /// </summary>
    [SiteContentType(GUID = "aca32225-b39f-4211-b412-927dc2b58dc4",
         AvailableInEditMode = false)] // Should not be created and added to content areas by editors, the SiteLogotypeBlock is only used as a property type
    public class SiteLogoBlock : SiteBlockData
    {
        /// <summary>
        /// Gets the site logotype URL
        /// </summary>
        /// <remarks>If not specified a default logotype will be used</remarks>
        [DefaultDragAndDropTarget]
        [UIHint(UIHint.Image)]
        public virtual Url Url
        {
            get
            {
                var url = this.GetPropertyValue(b => b.Url);

                return url == null || url.IsEmpty()
                           ? new Url("/Static/gfx/logotype.png")
                           : url;
            }
            set
            {
                this.SetPropertyValue(b => b.Url, value);
            }
        }

        [CultureSpecific]
        public virtual string Title { get; set; }
    }
}