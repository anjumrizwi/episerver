using EPiServer.DataAnnotations;

namespace EPiServerDemoSite.Models
{
    public class SiteImageUrl : ImageUrlAttribute
    {
        /// <summary>
        /// The parameterless constructor will initialize a SiteImageUrl attribute with a default thumbnail
        /// </summary>
        public SiteImageUrl() : base("~/Static/gfx/fallows-media-wide.jpg")
        {

        }

        public SiteImageUrl(string path) : base(path)
        {

        }
    }
}