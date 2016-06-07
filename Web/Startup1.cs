using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            //  app.Use<HelloTest>(); 
            app.Use(async (context, next) =>
            {
                context.Response.Headers["X_TEST-ID"] = System.Guid.NewGuid().ToString();
                await next.Invoke();
            });
            /* для ответов ввиде JSON  */
            /* var jSonProp = config.Formatters.JsonFormatter.SerializerSettings;
            jSonProp.Formatting = Newtonsoft.Json.Formatting.Indented;
            jSonProp.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var xml = config.Formatters.XmlFormatter;
            config.Formatters.Remove(xml); */
            app.UseWebApi(config);
        }
    }
}

