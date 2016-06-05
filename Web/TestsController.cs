using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web {
   public class TestsController : ApiController {
       
        public Message Get() {
            return new Message {Text="Hello World" } ;
        }
    }
   public class Message {
        public string Text { get; set; }
    }
    
}
