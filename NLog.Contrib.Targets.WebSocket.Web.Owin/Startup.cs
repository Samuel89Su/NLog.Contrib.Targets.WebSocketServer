using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using Owin.WebSocket.Extensions;
using System;
using System.IO;

[assembly: OwinStartup(typeof(NLog.Contrib.Targets.WebSocket.Web.Owin.Startup))]

namespace NLog.Contrib.Targets.WebSocket.Web.Owin
{
    public class Startup
    {
        private const string Path_Viewer = "websocketloggerviewer";

        private static readonly string BaseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path_Viewer);

        private const string BasePath = "/wslogger";
        private const string Path_Listen = BasePath + "/listen";


        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            var fileServerOptions = new FileServerOptions
            {
                RequestPath = new PathString("/" + Path_Viewer),
                FileSystem = new PhysicalFileSystem(BaseDir),
            };
            app.UseFileServer(fileServerOptions);

            //For static routes http://foo.com/ws use MapWebSocketRoute and attribute the WebSocketConnection with [WebSocketRoute('/ws')]
            app.MapWebSocketRoute<WebSocketLogListener>(Path_Listen);
        }
    }
}
