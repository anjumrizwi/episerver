using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace EPiServerDemoSite.Models.Media
{
    [ContentType(GUID = "34f52201-384f-4730-b7d7-7e4179b28441")]
    [MediaDescriptor(ExtensionString = "mp4")]
    public class VideoFile : VideoData
    {
        public virtual string VideoName { get; set; }

        [UIHint(UIHint.Video)]
        public virtual ContentReference ContentRef { get { return this.ContentLink; } }

        public virtual string VideoUrl
        {
            get
            {
                var locator = ServiceLocator.Current.GetInstance<UrlResolver>();
                return locator.GetUrl(this.ContentLink);
            }
        }
    }
}