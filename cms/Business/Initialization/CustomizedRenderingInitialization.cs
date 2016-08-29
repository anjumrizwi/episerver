using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServerSimpleSite.Business.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPiServerSimpleSite.Business.Initialization
{
    /// <summary>
    /// Module for customizing templates and rendering.
    /// </summary>
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CustomizedRenderingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //Add custom view engine allowing partials to be placed in additional locations
            //Note that we add it first in the list to optimize view resolving when using DisplayFor/PropertyFor
            ViewEngines.Engines.Insert(0, new SiteViewEngine());

            context.Locate.TemplateResolver()
                .TemplateResolved += TemplateCoordinator.OnTemplateResolved;
        }

        public void Uninitialize(InitializationEngine context)
        {
            ServiceLocator.Current.GetInstance<TemplateResolver>()
                .TemplateResolved -= TemplateCoordinator.OnTemplateResolved;
        }

        public void Preload(string[] parameters)
        {
        }
    }

    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FixQueryableNotificationUsersInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.RemoveAll<EPiServer.Notification.IQueryableNotificationUsers>();
            context.Services.AddTransient<EPiServer.Notification.IQueryableNotificationUsers>((s) => s.GetInstance<EPiServer.Security.SynchronizingUserService>());
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}