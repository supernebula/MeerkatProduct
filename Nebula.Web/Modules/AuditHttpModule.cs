﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using log4net;

namespace Nebula.Web.Modules
{
    public class AuditHttpModule : IHttpModule
    {
        private ILog _log;
        private string _logInfo;

        public AuditHttpModule()
        {
            _log = LogManager.GetLogger("loginfo");
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += ApplicationBeginRequest;
            context.EndRequest += ApplicationEndRequest;
        }

        public void ApplicationBeginRequest(object sender, EventArgs e)
        {
            var httpApplication = (HttpApplication) sender;
            httpApplication.Response.Write("这是来自自定义HttpModule中有BeginRequest");
            var request = httpApplication.Request;
            var rawUrl = request.RawUrl;
            var method = request.HttpMethod;
            if (request.InputStream.CanSeek)
                request.InputStream.Position = 0;
            var raw = new StreamReader(request.InputStream, Encoding.UTF8).ReadToEnd();
            var contentType = request.ContentType;
            var userHostAddress = request.UserHostAddress;

            _logInfo = $"Method:{method}  UserHostIP:{userHostAddress}  RequestUrl:{rawUrl}  ContentType:{contentType}\r\nRrquestRaw:\r\n{raw}";
            httpApplication.Response.Write("</br>" + _logInfo);
            httpApplication.Response.Write("</br>Reqeust Timestamp:" + httpApplication.Context.Timestamp);
            httpApplication.Response.Write("</br>");
        }

        public void ApplicationEndRequest(object sender, EventArgs e)
        {
            var httpApplication = (HttpApplication)sender;
            httpApplication.Response.Write("这是来自自定义HttpModule中有EndRequest");
            var start = new TimeSpan(httpApplication.Context.Timestamp.Ticks);
            var end = new TimeSpan(DateTime.Now.Ticks);
            var elapsed = end.Subtract(start).Milliseconds;

            _logInfo = $"StartTime:{httpApplication.Context.Timestamp.ToString("yyyy-MM-dd hh:mm:ss:fff")}   TotalMillisecond:{elapsed}\r\n" + _logInfo;
            _log.Info(_logInfo);
            
            httpApplication.Response.Write("</br>" + _logInfo);
            httpApplication.Response.Write("</br> HttpStatusCode:" + httpApplication.Response.StatusCode);
        }

        public void Dispose()
        {
        }
    }
}