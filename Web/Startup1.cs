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
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }                                             
                );
           // для ответов ввиде JSON
            var jSonProp = config.Formatters.JsonFormatter.SerializerSettings;
            jSonProp.Formatting = Newtonsoft.Json.Formatting.Indented;
            jSonProp.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var xml = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xml);

            app.UseWebApi(config);
        }
    }
}

