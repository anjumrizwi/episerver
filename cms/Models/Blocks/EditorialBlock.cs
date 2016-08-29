using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSimpleSite.Models.Blocks
{
    [SiteContentType(GUID = "e4747ef7-408d-44a9-aa83-d500a38f2512", GroupName = SystemTabNames.Content)]
    public class EditorialBlock : SiteBlockData
    {
        [CultureSpecific]
        [Display(GroupName = SystemTabNames.Content)]
        public virtual XhtmlString MainBody { get; set; }

    }
}