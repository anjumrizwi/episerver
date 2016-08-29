using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerSimpleSite.Models.Media
{
    [ContentType(DisplayName = "GenericMedia", GUID = "7e717772-ddb5-484c-8162-00036023fa80", Description = "")]
    public class GenericMedia : MediaData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Description",
            Description = "Description field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Description { get; set; }
    }
}