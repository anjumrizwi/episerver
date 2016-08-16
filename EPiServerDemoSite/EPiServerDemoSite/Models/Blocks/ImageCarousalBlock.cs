using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServerDemoSite.Models.Media;

namespace EPiServerDemoSite.Models.Blocks
{
    [ContentType(DisplayName = "ImageCarousalBlock", GUID = "55c33d4c-ec25-4fb1-9e2b-fd6adaeb5291", Description = "")]
    public class ImageCarousalBlock : CarousalBlockData
    {
    }
}