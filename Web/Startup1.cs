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
            try
            {
                app.Use<HelloTest>();           
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                    );                           
                app.UseWebApi(config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Owin:"+e.Message);
            }
        }
    }
}

