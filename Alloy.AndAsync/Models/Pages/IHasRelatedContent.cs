using EPiServer.Core;

namespace Alloy.AndAsync.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
