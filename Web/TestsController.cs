using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web {
    using Models;
    using System.Net;
    using System.Net.Http;
    public class TestController : ApiController {
        private static List<Task> Tasks = new List<Task>
        {
            new Task (1,"test1",new DateTime(2016,07,12)),
            new Task (2,"test2",new DateTime(2016,08,13)),
            new Task (3,"test3",new DateTime(2017,03,14))
        };

        //get
        public ActionResult<List<Task>> Get() {           
            Console.WriteLine("apiTest");
            ActionResult<List<Task>> response = new ActionResult<List<Task>>(Request,Tasks);           
            return response;
        }
        //get(task)
        public HttpResponseMessage Get(int id) {           
            var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);                       
            if (task == null) {
                HttpResponseMessage respon = Request.CreateResponse(HttpStatusCode.NotFound);
                return respon;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, task);          
            response.Headers.Add("X-TEST-ID", new string[] { Guid.NewGuid().ToString() });
            return response;
        }
        //delete(task)
        public IHttpActionResult Delete(int id) {
            var Task = Tasks.FirstOrDefault(t => t.GUID_Id == id);
            if (Task == null) {
                return NotFound();
            }
            Request.Content.Headers.Add("X-TEST-ID", new string[] { Guid.NewGuid().ToString() });
            Tasks.Remove(Task);
            return Ok(Tasks);
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
            
            return Ok(Tasks);
        }
        //put
        public IHttpActionResult Put(Task task) {
            if (task == null) {
                return BadRequest("Argument Null");
            }
            var FindTask = Tasks.FirstOrDefault(t => t.GUID_Id == task.GUID_Id);
            if (FindTask == null) {
                return NotFound();
            }
            FindTask.Title = task.Title;
            FindTask.Deadline = task.Deadline;

            return Ok(Tasks);
        }
    }

}