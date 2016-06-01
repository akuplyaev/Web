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
            string adress = "http://localhost:9081";
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(url:adress))
            {
                Console.WriteLine(adress);
                Console.ReadLine();
            }
          
        }
    }
}
