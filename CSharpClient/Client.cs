using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CSharpClient
{
    public class Client
    {
        public Client(TextWriter traceWriter)
        {
        }
        private void ReportTracker(string progress)
        {
            Console.WriteLine("Progress: {0}", progress);
        }
        private void ReportTrackerJustInTime(int progress)
        {
            Console.WriteLine("Progress: {0}", progress);
        }
        public async Task GetTrackers(string url)
        {
            Console.WriteLine("Starting..a long running job with progress coming in as strings");

            try
            {
                var hubConnection = new HubConnection(url);
                IHubProxy proxy = hubConnection.CreateHubProxy("TrackingHub");
                proxy.On("AddTracker", percent => ReportTracker(percent));
                await hubConnection.Start();
                Task<string> t1 = proxy.Invoke<string>("DoLongRunningThingAsync");
                await t1;
                Console.WriteLine(t1.Result);
                hubConnection.Stop();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: {0}", exception);
                throw;
            }
        }

        public async Task GetTrackersWithJustInTimeProgress(string url)
        {
            Console.WriteLine("Starting..a long running job with progress coming in as ints");

            try
            {
                var hubConnection = new HubConnection(url);
                IHubProxy proxy = hubConnection.CreateHubProxy("TrackingHub");
                await hubConnection.Start();
                Task<string> t1 = proxy.Invoke<string, int>("DoLongRunningThingWithJustInTimeProgressAsync", ReportTrackerJustInTime);
                await t1;
                Console.WriteLine(t1.Result);

                hubConnection.Stop();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception: {0}", exception);
                throw;
            }
        }
    }
}
