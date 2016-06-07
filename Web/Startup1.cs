using Microsoft.Owin;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
             // app.Use<HelloTest>(); 
            /*      app.Use(async (context, next) =>
                   {
                       Console.WriteLine("До 1");
                       Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);
                       await next();
                       Console.WriteLine("После 1");
                       Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);
                   });
                   app.Use(async (context, next) =>
                   {
                       Console.WriteLine("до 2");
                       Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);
                       //context.Response.Headers["X-TEST-ID"] = System.Guid.NewGuid().ToString();
                       await next();
                       Console.WriteLine("После 2");
                       Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);
                   });*/
            app.Use(async (context, next) =>
            {
                Console.WriteLine("до 3");
                Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);                
                await next();
                Console.WriteLine("После 3");
                //context.Response.Headers["X-TEST-ID"] = Guid.NewGuid().ToString();
                context.Response.Headers.Add("X-TEST-ID",new string[] { Guid.NewGuid().ToString() });
                Console.WriteLine("X-TEST-ID:" + context.Response.Headers["X-TEST-ID"]);
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

