using System.ComponentModel.DataAnnotations;

using EPiServerDemoSite.Models.Entities;

using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerDemoSite.Models.Blocks
{
    [ContentType(DisplayName = "Postal Address Block", Description = "Shipping Address Block", GUID = "EC61EA99-0018-4034-942C-ED341B0CD625")]
    public class PostalAddressBlock : SiteBlockData
    {
        public PostalAddressBlock()
        {
            Address = new PostalAddress();
        }

        [Ignore]
        public PostalAddress Address { get; set; }

        [Display(Name = "Heading", GroupName = SystemTabNames.Content, Order = 100)]
        [Required]
        public virtual string Heading { get; set; }

        [Display(Name = "Address Line 1", GroupName = SystemTabNames.Content, Order = 200)]
        [Required]
        public virtual string Address1Text { get; set; }

        [Display(Name = "Address Line 2", GroupName = SystemTabNames.Content, Order = 300)]
        [Required]
        public virtual string Address2Text { get; set; }

        [Display(
            Name = "Town/City", GroupName = SystemTabNames.Content, Order = 400)]
        [Required]
        public virtual string TownText { get; set; }

        [Display(Name = "Postcode", GroupName = SystemTabNames.Content, Order = 500)]
        [Required]
        public virtual string PostcodeText { get; set; }
    }
}