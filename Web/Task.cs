﻿using System;
using System.Runtime.Serialization;
namespace Web.Models {
   
    public class Task  {
        public int GUID_Id { get; set; }       
        public string Title { get; set; }    
        public string Deadline { get; set; }
        public Task() {
        }
        public Task(int guid, string title, DateTime deadline) {
            GUID_Id = guid;
            Title = title;
            Deadline = deadline.ToShortDateString();
        }
    }
}

