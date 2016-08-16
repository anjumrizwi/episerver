using EPiServer.Core;
using EPiServer.SpecializedProperties;

namespace EPiServerDemoSite.Models.ViewModels
{
    public class LayoutModel
    {
        public LinkItemCollection Pages { get; set; }

        public XhtmlString Footer { get; set; }

        public XhtmlString Header { get; set; }
    }
}