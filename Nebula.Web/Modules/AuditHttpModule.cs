using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using log4net;
using log4net.Config;
using log4net.Core;

namespace Nebula.Web.Modules
{
    public class AuditHttpModule : IHttpModule
    {
        private ILogger _logger;
        private DateTime _startTime;
        private DateTime _endTime;
        private readonly Stopwatch _stopwatch;

        public AuditHttpModule()
        {
            _logger = LoggerManager.GetLogger("","");
            _stopwatch = new Stopwatch();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ApplicationBeginRequest);
            context.EndRequest += new EventHandler(ApplicationEndRequest);
        }

        public void ApplicationBeginRequest(object sender, EventArgs e)
        {
            var httpApplication = (HttpApplication) sender;
            var request = httpApplication.Request;
            var rawUrl = request.RawUrl;
            var method = request.HttpMethod;
            if (request.InputStream.CanSeek)
                request.InputStream.Position = 0;
            var raw = new StreamReader(request.InputStream, Encoding.UTF8).ReadToEnd();
            var contentType = request.ContentType;
            var userHostAddress = request.UserHostAddress;

            _startTime = DateTime.Now;
            _stopwatch.Start();
            _logger.Log();
        }

        public void ApplicationEndRequest(object sender, EventArgs e)
        {

            _stopwatch.Stop();
            var elapsed = _stopwatch.ElapsedMilliseconds;
            _endTime = DateTime.Now;
        }

        public void Dispose()
        {
        }
    }
}
