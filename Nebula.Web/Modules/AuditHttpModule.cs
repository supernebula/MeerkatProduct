using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using log4net;

namespace Nebula.Web.Modules
{
    public class AuditHttpModule : IHttpModule
    {
        private ILog _log;
        private DateTime _startTime;
        private DateTime _endTime;
        private readonly Stopwatch _stopwatch;
        private string _logInfo;

        public AuditHttpModule()
        {
            _log = LogManager.GetLogger("AuditHttpModule");
            _stopwatch = new Stopwatch();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += ApplicationBeginRequest;
            context.EndRequest += ApplicationEndRequest;
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
            _logInfo = $"Method:{method}  UserHostIP:{userHostAddress}  RequestUrl:{rawUrl}  ContentType:{contentType}\r\nRrquestRaw:\r\n{raw}";
        }

        public void ApplicationEndRequest(object sender, EventArgs e)
        {
            _stopwatch.Stop();
            var elapsed = _stopwatch.ElapsedMilliseconds;
            _endTime = DateTime.Now;
            _logInfo = $"StartTime:{_startTime.ToString("yyyy-MM-dd hh:mm:ss:fff")}  EndTime:{_endTime.ToString("yyyy-MM-dd hh:mm:ss:fff")}   TotalMillisecond:{elapsed}\r\n" + _logInfo;
            _log.Info(_logInfo);
        }

        public void Dispose()
        {
        }
    }
}
