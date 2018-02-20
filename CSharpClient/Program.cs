using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = Console.Out;
            var client = new Client(writer);
            string url = "http://localhost:9000";
            client.GetTrackers(url).Wait();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            client.GetTrackersWithJustInTimeProgress(url).Wait();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
