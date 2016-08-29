using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace EPiServerSimpleSite.Models.Pages
{
    /// <summary>
    /// Used for logging in on the website
    /// </summary>
    [SiteContentType(GroupName = Global.GroupNames.Specialized, GUID = "38253cb4-895a-4eb8-96f6-941d29c5203d")]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-article.png")]
    public class LoginPage : StandardPage
    {
        
    }
}