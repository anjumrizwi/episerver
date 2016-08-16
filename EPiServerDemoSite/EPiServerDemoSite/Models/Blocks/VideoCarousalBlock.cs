using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EPiServerDemoSite.Models.Blocks
{
    [ContentType(DisplayName = "VideoCarousalBlock", GUID = "5acedf85-2b66-4814-87ac-c852888ea454", Description = "")]
    public class VideoCarousalBlock : CarousalBlockData
    {
    }
}