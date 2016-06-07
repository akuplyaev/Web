using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web
{
    public class ActionResult<T> :IHttpActionResult
    {
        private readonly T _t;
        private readonly HttpRequestMessage _request;        
        public ActionResult (HttpRequestMessage request,T t)
        {
            _request = request;
            _t = t;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = _request.CreateResponse(HttpStatusCode.Found,_t);
         //   response.Headers.Add("X_TEST-ID", new string[] { Guid.NewGuid().ToString() });           
            return Task.FromResult(response);           
        }
    }
}
