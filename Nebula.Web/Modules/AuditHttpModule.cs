using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;

namespace Nebula.Web.Modules
{
    public class AuditHttpModule : IHttpModule
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private Stopwatch _stopwatch;

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
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
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
