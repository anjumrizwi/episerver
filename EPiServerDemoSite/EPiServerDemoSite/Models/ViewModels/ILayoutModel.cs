using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.Web;

namespace EPiServerDemoSite.Models.ViewModels
{
    public interface ILayoutModel
    {
        [UIHint(UIHint.Image)]
        ContentReference Logo { get; set; }
        XhtmlString Footer { get; set; }
        XhtmlString Header { get; set; }

    }
}