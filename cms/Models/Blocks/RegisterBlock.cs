using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerSimpleSite.Models.Entities;

namespace EPiServerSimpleSite.Models.Blocks
{
    [SiteContentType(DisplayName = "RegisterBlock", GUID = "651d4c33-540c-4b51-8fde-320138bc39bd", Description = "User registeration block.")]
    [SiteImageUrl]
    public class RegisterBlock : SiteBlockData
    {
        public RegisterBlock()
        {
            UserInfo = new UserDetail();
        }

        [Ignore]
        public UserDetail UserInfo { get; set; }

        [Required]
        [CultureSpecific]
        [Display(Name = "Headine line", GroupName = SystemTabNames.Content, Order = 10)]
        public virtual string HeadingLineText { get; set; }

        [Required]
        [CultureSpecific]
        [Display(Name = "User Name", GroupName = SystemTabNames.Content, Order = 20)]
        public virtual string UserNameText { get; set; }

        [Required]
        [CultureSpecific]
        [Display(Name = "Password", GroupName = SystemTabNames.Content, Order = 30)]
        public virtual string PasswordText { get; set; }

        [Required]
        [CultureSpecific]
        [Display(Name = "EmailId", GroupName = SystemTabNames.Content, Order = 40)]
        public virtual string EmailIdText { get; set; }
    }
}