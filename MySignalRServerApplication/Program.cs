using System;

namespace MySignalRServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:9000";
            using (Microsoft.Owin.Hosting.WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
}
