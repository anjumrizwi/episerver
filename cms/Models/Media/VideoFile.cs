using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;

namespace EPiServerSimpleSite.Models.Media
{
    [ContentType(DisplayName = "VideoFile", GUID = "acc1bc13-ea2c-49ed-bb7f-deac67a196b6", Description = "This is a video file.")]
    [MediaDescriptor(ExtensionString = "flv,mp4,webm")]
    public class VideoFile : VideoData
    {
        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public virtual string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the URL to the preview image.
        /// </summary>
        [UIHint(UIHint.Image)]
        public virtual ContentReference PreviewImage { get; set; }

    }
}