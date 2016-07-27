using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;

namespace EPiServerSimpleSite.Models.Media
{
    [ContentType(DisplayName = "ImageFile", GUID = "43443761-6d5a-4a89-826c-bdde2cec2b94", Description = "This is an image file.")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFile : ImageData
    {

        [CultureSpecific]
        [Editable(true)]
        [Display(
            Name = "Image file",
            Description = "Image file field's description",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Description { get; set; }
    }
}