using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web {   
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    class HelloTest {
        private readonly AppFunc _next;
        public HelloTest(AppFunc next) {
            _next = next;
        }
        
        public  Task Invoke(IDictionary<string, object> env)
        {         
            var response = env["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(response)) {
                return writer.WriteAsync("Hello World");
            }
        }
    }
      
}
