using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace EPiServerDemoSite.Models.Blocks
{
    [ContentType(DisplayName = "ContactusBlock", GUID = "1151920c-0be1-49c2-a0f6-0394ddde62af", Description = "")]
    public class ContactusBlock : BlockData
    {
        public virtual string Caption { get; set; }
        public virtual string Email { get; set; }
    }
}