using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            try {
                app.Use<HelloTest>();
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { controller = "test", id = RouteParameter.Optional }
                    );
                app.UseWebApi(config);
            }
            catch (Exception e) {
                Console.WriteLine("Owin:" + e.Message);
            }
        }
    }
}

