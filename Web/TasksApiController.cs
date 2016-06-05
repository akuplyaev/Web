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
        //get
        public List<Task> Get() {                      
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
        public List<Task> Delete(int id) {
            var task = Tasks.FirstOrDefault(t => t.GUID_Id == id);
            if (task == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Tasks.Remove(task);
            return  Tasks;
        }
        //post
        public List<Task> Post(Task task) {
            if (task == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var TaskExists = Tasks.Any(t => t.GUID_Id == task.GUID_Id);

            if (TaskExists) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Tasks.Add(task);
            return Tasks;           
        }
        //put
        public List<Task> Put(Task task) {
            if (task == null) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var FindTask = Tasks.FirstOrDefault(t => t.GUID_Id == task.GUID_Id);
            if (FindTask == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            FindTask.Title = task.Title;
            FindTask.Deadline = task.Deadline;

            return Tasks;
        }
    }

}



