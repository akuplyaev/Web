using Microsoft.Owin;
using Owin;
using Newtonsoft.Json;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json.Serialization;
using Web.Models;
using System;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web {
    public class Startup {       
        public void Configuration(IAppBuilder app) {
                app.Use<OwinException>();
                app.Use<HelloTest>();
                var webapiconfig = ConfigureWebApi();
            app.Use(async (context, next) =>
            {
                try{
                    await next();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Web-API:" + e.Message);
                    // Console.WriteLine("Web-API:" + e.Response.StatusCode);
                }
            });
            app.UseWebApi(webapiconfig);          
        }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            return config;
        }
    }
}

