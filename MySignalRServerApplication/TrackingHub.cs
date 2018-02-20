using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace MySignalRServerApplication
{
    public class TrackingHub : Hub
    {
        public async Task<string> DoLongRunningThingAsync()
        {
            for (int i = 0; i <= 100; i += 5)
            {
                await Task.Delay(200);
                Clients.Caller.AddTracker(string.Format(" {0}% of {1}%", i, 100));
            }
            return "Job complete!";
        } 

        public async Task<string> DoLongRunningThingWithJustInTimeProgressAsync(IProgress<int> progress)
        {
            for (int i = 0; i <= 100; i += 5)
            {
                await Task.Delay(200);
                progress.Report(i);
            }
            return "Job complete!";
        }
    }
}

