using System;
using System.Web.Mvc;

namespace EPiServerDemoSite
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        protected override void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            base.RegisterRoutes(routes);
            //routes.MapRoute("default", "{controller}/{action}", new { controller = "ContactUsBlockController", action = "SendMail" });
            routes.MapRoute("default", "{controller}/{action}", new { action = "index" });
        }
    }
}