using Microsoft.Owin.Hosting;
using System;



namespace Web {
    class Program {
        static void Main(string[] args) {
            string adress = "http://localhost:9081";
            //using (WebApp.Start<Startup1>(new StartOptions { Port = 8081 }))
            using (WebApp.Start<Startup>(url: adress))
            {
				Console.WriteLine(adress);
                Console.ReadLine();
            }
        }
    }
}
