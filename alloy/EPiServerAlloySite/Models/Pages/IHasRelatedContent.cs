using EPiServer.Core;

namespace EPiServerAlloySite.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
