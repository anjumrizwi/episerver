using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerDemoSite.Models.Blocks;

namespace EPiServerDemoSite.Models.Forms
{
    public class BaseFormModel<T> where T : SiteBlockData
    {
        public PageReference CurrentPageLink { get; set; }

        public ContentReference CurrentBlockLink { get; set; }

        public string CurrentLanguage { get; set; }

        public T ParentBlock { get; set; }
    }
}