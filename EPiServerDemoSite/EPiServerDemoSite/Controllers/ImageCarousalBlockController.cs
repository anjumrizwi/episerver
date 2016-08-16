using System.Web.Mvc;
using EPiServer.Web.Mvc;
using EPiServerDemoSite.Models.Blocks;

namespace EPiServerDemoSite.Controllers
{
    public class ImageCarousalBlockController : BlockController<ImageCarousalBlock>
    {
        public override ActionResult Index(ImageCarousalBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
