﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Web
{
    public class MyApiException : ExceptionFilterAttribute
    {
        public Type ExceptionType { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine("Web-API: "+actionExecutedContext.Exception.Message);           
        }


    }
}
