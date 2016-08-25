using EPiServerDemoSite.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPiServerDemoSite.Models.ViewModels
{
    public class FormPageModel : PageViewModel<FormPage>
    {
        public FormPageModel(FormPage currentPage)
            : base(currentPage)
        {
        }
    }
}