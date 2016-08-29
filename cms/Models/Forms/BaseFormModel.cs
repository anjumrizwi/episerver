using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerSimpleSite.Models.Blocks;

namespace EPiServerSimpleSite.Models.Forms
{
    public class BaseFormModel<T> where T : SiteBlockData
    {
        public PageReference CurrentPageLink { get; set; }

        public ContentReference CurrentBlockLink { get; set; }

        public string CurrentLanguage { get; set; }

        public T ParentBlock { get; set; }
    }
}