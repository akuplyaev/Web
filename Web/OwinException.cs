using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web
{

    using AppFunc = Func<IDictionary<string, object>, Task>;
    class OwinException
    {
        private readonly AppFunc _next;
        public OwinException(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            try
            {
              await  _next.Invoke(env);
            }
            catch(Exception e)
            {
                Console.WriteLine("Owin:" + e.Message);
            }
        }
    }
}
