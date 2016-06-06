using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Web
{
    class Program
    {
        static void Main(string[] args)
        {
            string adress = "http://localhost:8081";
            //using (WebApp.Start<Startup1>(new StartOptions { Port = 8081 }))
            using (WebApp.Start<Startup>(url:adress)){
                Console.WriteLine(adress);
                Console.ReadLine();
            }
            
        }
    }
}
