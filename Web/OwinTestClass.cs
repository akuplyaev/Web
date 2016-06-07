using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web {
    using Microsoft.Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class HelloTest  {
        private readonly AppFunc _next;
        public HelloTest(AppFunc next) {
            _next = next;
        }
        public async  Task Invoke(IDictionary<string, object> env) {            
            var response = new OwinResponse(env);                     
            if (response.Context.Request.Path.Value == "/") {
               // await response.WriteAsync("Hello World");               
            }
            else {               
                Console.WriteLine("midlware до");               
                await _next.Invoke(env);
                Console.WriteLine("midlware после");
                response = new OwinResponse(env);
                response.Headers.Add("X_TEST-ID", new string[] { Guid.NewGuid().ToString() });
                              
            }         
        }
    }
}