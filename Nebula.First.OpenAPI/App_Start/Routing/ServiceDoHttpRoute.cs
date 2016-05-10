using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Xml;

namespace Nebula.First.OpenAPI.Routing
{
    class ServiceDoHttpRoute : HttpRoute
    {
        //
        // 摘要:
        //     通过查找路由的 System.Web.Http.Routing.HttpRouteData 来确定该路由是否是传入请求的匹配项。
        //
        // 参数:
        //   virtualPathRoot:
        //     虚拟路径根。
        //
        //   request:
        //     HTTP 请求。
        //
        // 返回结果:
        //     如果匹配，则为该路由的 System.Web.Http.Routing.HttpRouteData；否则为 null。
        public override IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            if (!request.RequestUri.PathAndQuery.StartsWith("/api/service/do", StringComparison.CurrentCultureIgnoreCase))
                return null;
            //Stream reqStream = request.Content.ReadAsStreamAsync().Result;
            //if (reqStream.CanSeek)
            //    reqStream.Position = 0;
            //var content = new StreamReader(reqStream, Encoding.UTF8).ReadToEnd();
            //string intfaceName;
            //var document = new XmlDocument();
            //try
            //{
            //    document.LoadXml(content);
            //    var intfaceNode = document.SelectSingleNode("//Interface");
            //    intfaceName = intfaceNode == null
            //        ? null
            //        : intfaceNode.InnerText.Trim();
            //}
            //catch
            //{
            //    return null;
            //}

            if (!request.Headers.Contains("Interface"))
                return null;
            var intfaceName = request.Headers.GetValues("Interface").First();

            if (string.IsNullOrWhiteSpace(intfaceName) || !intfaceName.Contains(".") || intfaceName.StartsWith(".") || intfaceName.EndsWith("."))
                return null;

            var paths = intfaceName.Split('.');
            if (paths.Length == 2)
            {
                var controller = paths[0];
                var action = paths[1];
                var httpRouteValueDictionary = new HttpRouteValueDictionary(new { controller, action, id = RouteParameter.Optional });
                var data = new HttpRouteData(new HttpRoute("api/{controller}/{action}/{id}", httpRouteValueDictionary));
                return data;
            }
            return null;
        }


        // 摘要:
        //     尝试生成一个 URI，该 URI 表示基于 System.Web.Http.Routing.HttpRouteData 的当前值传入的值，并使用指定的 System.Web.Http.Routing.HttpRoute
        //     生成新值。
        //
        // 参数:
        //   request:
        //     HTTP 请求消息。
        //
        //   values:
        //     路由值。
        //
        // 返回结果:
        //     System.Web.Http.Routing.HttpVirtualPathData 实例或 null（如果无法生成 URI）。
        public override IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values)
        {
            throw new NotImplementedException();
        }
    }
}
