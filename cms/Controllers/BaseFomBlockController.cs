using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace EPiServerSimpleSite.Controllers
{
    public class BaseFomBlockController<T> : BlockController<T> where T : BlockData
    {
        protected virtual void SaveModelState(ContentReference blockLink)
        {
            TempData[StateKey(blockLink)] = ViewData.ModelState;
        }

        protected virtual void LoadModelState(ContentReference blockLink)
        {
            var key = StateKey(blockLink);
            var modelState = TempData[key] as ModelStateDictionary;

            if (modelState != null)
            {
                ViewData.ModelState.Merge(modelState);
                TempData.Remove(key);
            }
        }

        private string StateKey(ContentReference blockLink)
        {
            return "FormBlock_" + blockLink.ID;
        }
    }
}
