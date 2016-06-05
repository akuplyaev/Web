using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web {
    using Models;
    using System.Net;
    public class TestController : ApiController {
        private static List<Task> Tasks = new List<Task>
        {
            new Task (1,"test1",new DateTime(2016,07,12)),
            new Task (2,"test2",new DateTime(2016,08,13)),
            new Task (3,"test3",new DateTime(2017,03,14))
        };

        //get
        public IEnumerable<Task> Get() {
            return Tasks;
        }
        //get(task)
        public Task Get(int id) {
            var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);

            if (task == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return task;
        }
        //delete(task)
        public IHttpActionResult Delete(int id) {
            var Task = Tasks.FirstOrDefault(t => t.GUID_Id == id);
            if (Task == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Tasks.Remove(Task);
            return Ok();
        }
        //post
        public IHttpActionResult Post(Task task) {
            if (task == null) {
                return BadRequest("Argument Null");
            }
            var TaskExists = Tasks.Any(t => t.GUID_Id == task.GUID_Id);

            if (TaskExists) {
                return BadRequest("Exists");
            }
            Tasks.Add(task);
            return Ok();
        }
        //put
        public IHttpActionResult Put(Task task) {
            if (task == null) {
                return BadRequest("Argument Null");
            }
            var FindTask = Tasks.FirstOrDefault(t => t.GUID_Id == task.GUID_Id);
            if (FindTask == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            FindTask.Title = task.Title;
            FindTask.Deadline = task.Deadline;

            return Ok();
        }
    }

}