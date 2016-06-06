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

        public Task Invoke(IDictionary<string, object> env) {
            var response = new OwinResponse(env);
            return response.WriteAsync("Hello World");

        }
    }
}


