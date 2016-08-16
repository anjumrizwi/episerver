using EPiServer.Core;

namespace EPiServerDemoSite.Models.ViewModels
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}