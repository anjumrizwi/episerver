using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;

namespace EPiServerDemoSite.Models.Blocks
{
    public class CarousalBlockData : BlockData
    {
        [UIHint(UIHint.MediaFolder)]
        [Display(
        Name = "Folder",
        GroupName = SystemTabNames.Content,
        Order = 1)]
        public virtual ContentReference FolderPath { get; set; }
    }
}