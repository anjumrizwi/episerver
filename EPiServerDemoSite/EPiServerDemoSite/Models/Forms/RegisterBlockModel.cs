using EPiServerDemoSite.Models.Blocks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EPiServerDemoSite.Models.Forms
{
    public class RegisterBlockModel : BaseFormModel<RegisterBlock>
    {
        [Required]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Email Address")]
        public string EmailId { get; set; }
    }
}