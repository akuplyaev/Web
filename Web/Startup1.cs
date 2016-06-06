using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<HelloTest>();
                                  
           /*  app.Run(context =>
             {
                 return context.Response.WriteAsync("Hello world");

             }); 
           */ 

        }
    }
}
