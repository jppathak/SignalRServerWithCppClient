using Microsoft.Owin.Cors;
using Owin;

namespace MySignalRServerApplication
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
