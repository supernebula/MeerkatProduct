using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace OpenAPI.Routing
{
    public class ServiceDoRoute : RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (!httpContext.Request.Url.PathAndQuery.StartsWith("service/do", StringComparison.CurrentCultureIgnoreCase))
                return null;
            Stream reqStream = httpContext.Request.InputStream;
            if (reqStream.CanSeek)
                reqStream.Position = 0;
            var content = new StreamReader(reqStream, Encoding.UTF8).ReadToEnd();
            string intfaceName = null;
            var document = new XmlDocument();
            try
            {
                document.LoadXml(content);
                var intfaceNode = document.SelectSingleNode("//Interface");
                intfaceName = intfaceNode == null
                    ? null
                    : intfaceNode.InnerText == null ? null : intfaceNode.InnerText.Trim();
            }
            catch
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(intfaceName) || !intfaceName.Contains(".") || intfaceName.StartsWith(".") || intfaceName.EndsWith("."))
                return null;

            var paths = intfaceName.Split('.');
            if (paths.Length == 3)
            {
                var data = new RouteData(this, new MvcRouteHandler());
                data.Values.Add("controller", paths[1]);
                data.Values.Add("action", paths[2]);
                return data;
            }

            if (paths.Length == 3)
            {
                var data = new RouteData(this, new MvcRouteHandler());
                data.Values.Add("controller", paths[1]);
                data.Values.Add("action", paths[2]);
                return data;
            }

            return null;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
