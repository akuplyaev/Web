using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web {
    using Models;
    using System.Net;
    [RoutePrefix("api/application/tasks")]
    public class TasksController : ApiController {
        private static List<Task> Tasks = new List<Task>
        {
            new Task (1,"test1",new DateTime(2016,07,12)),
            new Task (2,"test2",new DateTime(2016,08,13)),
            new Task (3,"test3",new DateTime(2017,03,14))
        };
        //get  
        [Route("all")]
        [Route("~/api/application/tasks")]
        public List<Task> Get() {
            return Tasks;
        }
        //get(task)
        [Route("list/{id=1}")]
        public Task Get(int id) {
            var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);
            try {
                if (task == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
            catch (HttpResponseException e) {
                Console.WriteLine("Web-API:" + e.Message);
                Console.WriteLine("Web-API:" + e.Response.StatusCode);
            }
            return task;
        }
        //delete(task)
        [Route("delete/{id=3}")]
        public List<Task> Delete(int id) {
            try {
                var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);
                if (task == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                Tasks.Remove(task);
            }
            catch (HttpResponseException e) {
                Console.WriteLine("Web-API:" + e.Message);
                Console.WriteLine("Web-API:" + e.Response.StatusCode);
            }
            return Tasks;
        }
        //post
        [Route("add")]
        public List<Task> Post(Task task) {
            try {
                if (task == null) {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var TaskExists = Tasks.Any(t => t.GUID_Id == task.GUID_Id);

                if (TaskExists) {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            catch (HttpResponseException e) {
                Console.WriteLine("Web-API:" + e.Message);
                Console.WriteLine("Web-API:" + e.Response.StatusCode);
            }
            Tasks.Add(task);
            return Tasks;
        }

        //put
        [Route("change/{id=1}")]
        public List<Task> Put(int id, Task task) {
            try {
                if (task == null) {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                var FindTask = Tasks.FirstOrDefault(t => t.GUID_Id == id);
                if (FindTask == null) {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                FindTask.GUID_Id = task.GUID_Id;
                FindTask.Title = task.Title;
                FindTask.Deadline = task.Deadline;
            }
            catch (HttpResponseException e) {
                Console.WriteLine("Web-API:" + e.Message);
                Console.WriteLine("Web-API:" + e.Response.StatusCode);
            }
            return Tasks;
        }
    }

}



