using EPiServerSimpleSite.Business.Rendering;

namespace EPiServerSimpleSite.Models.Pages
{
    /// <summary>
    /// Used to logically group pages in the page tree
    /// </summary>
    [SiteContentType(GUID = "aea0aa1c-989d-4848-b94d-c108d1177c75", GroupName = Global.GroupNames.Specialized)]
    public class ContainerPage : SitePageData, IContainerPage
    {

    }
}