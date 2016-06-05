using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web {
    using Models;
    using System.Net;
    public class TasksController : ApiController {
        private static List<Task> Tasks = new List<Task>
        {
            new Task (1,"test1",new DateTime(2016,07,12)),
            new Task (2,"test2",new DateTime(2016,08,13)),
            new Task (3,"test3",new DateTime(2017,03,14))
        };


        public List<Task> Get() {
            return Tasks;
        }

        public Task Get(int id) {
            var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);

            if (task == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return task;
        }
    }

}



