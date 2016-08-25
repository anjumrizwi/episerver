using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServerDemoSite.Models.ViewModels;

namespace EPiServerDemoSite.Models.Pages
{
    [SiteContentType(DisplayName = "FormPage", GUID = "fc89f524-5f91-4c24-b198-4246ab25d2e0", Description = "")]
    public class FormPage : EPiPageData, IHasRelatedContent
    {
        [Display(Name = "Contenet Area", GroupName = SystemTabNames.Content, Order = 10)]
        [AllowedTypes(new[] { typeof(IContentData) })]
        public virtual ContentArea RelatedContentArea { get; set; }
    }
}