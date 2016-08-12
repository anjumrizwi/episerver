using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerSimpleSite.Models.Entities;
using EPiServerSimpleSite.Models.Blocks;
using System.ComponentModel;

namespace EPiServerSimpleSite.Models.Forms
{
    public class RegisterBlockModel : BaseFormModel<RegisterBlock>
    {
        [DisplayName("Username")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string EmailId { get; set; }
    }
}