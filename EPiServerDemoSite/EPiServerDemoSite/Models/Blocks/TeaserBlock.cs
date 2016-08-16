using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EPiServerDemoSite.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlock", GUID = "eb82cd18-9d7e-433c-9c1b-a43dc0572180", Description = "")]
    //[SiteImageUrl(Global.StaticGraphicsFolderPath + "Teaser.png")]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
        Name = "Teaser Heading",
        GroupName = SystemTabNames.Content,
        Order = 20)]
        public virtual string TeaserHeading { get; set; }

        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
        Name = "Teaser Text",
        GroupName = SystemTabNames.Content,
        Order = 30)]
        [UIHint(UIHint.LongString)]
        public virtual string TeaserText { get; set; }

        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [UIHint(UIHint.Image)]
        [Display(
        Name = "Teaser Image",
        GroupName = SystemTabNames.Content,
        Order = 40)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(
        GroupName = SystemTabNames.Content,
        Order = 50)]
        public virtual PageReference Link { get; set; }

        //public virtual Url Link { get; set; }
    }
}