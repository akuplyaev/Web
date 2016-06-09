﻿using Microsoft.Owin;
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

