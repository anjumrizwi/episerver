using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServerDemoSite.Models.Blocks;

namespace EPiServerDemoSite.Controllers
{
    public class TeaserBlockController : BlockController<TeaserBlock>
    {
        public override ActionResult Index(TeaserBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
