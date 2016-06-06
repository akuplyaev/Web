using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web {
    using Microsoft.Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class HelloTest {
        private readonly AppFunc _next;
        public HelloTest(AppFunc next) {
            _next = next;
        }
        public async Task Invoke(IDictionary<string, object> env) {
            var response = new OwinResponse(env);
            if (response.Context.Request.Path.Value == "/") {
                await response.WriteAsync("Hello World");
            }
            response.Headers.Add("X_TEST-ID", new string[] { "dasd" });
            await _next.Invoke(env);
          //  response.Headers.Add("X_TEST-ID", new string[] { "dasd" }); 
            return;         
        }
    }
}