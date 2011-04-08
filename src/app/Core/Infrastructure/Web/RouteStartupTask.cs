using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core;

namespace FakeVader.Core.Infrastructure.Web {
    public class RouteStartupTask : IStartable {
        public void Start() {
            var routes = RouteTable.Routes;
            routes.Clear();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        public void Stop() {
        }
    }
}