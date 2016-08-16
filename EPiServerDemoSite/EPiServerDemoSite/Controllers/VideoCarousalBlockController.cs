using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerDemoSite.Models.Blocks;

namespace EPiServerDemoSite.Controllers
{
    public class VideoCarousalBlockController : BlockController<VideoCarousalBlock>
    {
        public override ActionResult Index(VideoCarousalBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
