using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Web
{
    public class ActionRes: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {           
            
            actionExecutedContext.Response.Headers.Add("X-TEST-ID", Guid.NewGuid().ToString());
        }

    }
}
