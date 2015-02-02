using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Routing;

namespace System.Web.Mvc {
    public static class UrlHelpers {

        public static string Absolute(this UrlHelper urlHelper, string relativeOrAbsoluteUrl, bool replaceProtocal = false)
        {
            var uri = new Uri(relativeOrAbsoluteUrl, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri) {
                return replaceProtocal == true ? SetProtocol(relativeOrAbsoluteUrl) : relativeOrAbsoluteUrl;
            }

            Uri combinedUri;

            var baseUri = new Uri(urlHelper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority));
            if (Uri.TryCreate(baseUri, relativeOrAbsoluteUrl, out combinedUri)) {
                return replaceProtocal == true ? SetProtocol(combinedUri.AbsoluteUri) : combinedUri.AbsoluteUri;
            }

            throw new Exception(string.Format("Could not create absolute url for {0} using baseUri{0}", relativeOrAbsoluteUrl, baseUri));
        }


        private static string SetProtocol(string url)
        {

            // does url have a protocol
            if (url.IndexOf("http://") > -1 || url.IndexOf("https://") > -1)
            {
                // gimme the port
                var port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                if (port == null || port == "80" || port == "443")
                {
                    port = "";
                }
                else
                {
                    port = ":" + port;
                }

                // gimme the protocal
                var protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                if (protocol == null || protocol == "0")
                {
                    // use http
                    protocol = "http://";
                }
                else
                {
                    protocol = "https://";
                }

                // replace the protocol 
                if (url.Contains("http://") && protocol == "https://")
                {
                    url = url.Replace("http://", protocol);
                    return url;
                }

                if (url.Contains("https://") && protocol == "http://")
                {
                    url = url.Replace("https://", protocol);
                    return url;
                }

            }
            return url;
        }




        public static string SiteRoot(HttpContextBase context) {
            return SiteRoot(context, true);
        }

        public static string RootRelUrl(HttpContextBase context, string path)
        {
            var url = SiteRoot(context, true) + path;
            return url;
        }

        
        public static string WebApiRoute(this UrlHelper urlHelper, string routeName, IDictionary<string, object> routeValues)
        {
            //urlHelper.ThrowIfArgumentNull("urlHelper");

            var newRouteValues = new RouteValueDictionary(routeValues);
            newRouteValues.Add("httproute", string.Empty);
            return urlHelper.RouteUrl(routeName, newRouteValues);
        }

        public static string WebApiRoute(this UrlHelper urlHelper, string routeName, object routeValues)
        {
            return WebApiRoute(urlHelper, routeName, new RouteValueDictionary(routeValues));
        }
        


        public static string SiteRoot(HttpContextBase context, bool usePort) {
            var Port = context.Request.ServerVariables["SERVER_PORT"];
            if (usePort) {
                if (Port == null || Port == "80" || Port == "443")
                    Port = "";
                else
                    Port = ":" + Port;
            }
            var Protocol = context.Request.ServerVariables["SERVER_PORT_SECURE"];
            if (Protocol == null || Protocol == "0")
                Protocol = "http://";
            else
                Protocol = "https://";

            var appPath = context.Request.ApplicationPath;
            if (appPath == "/")
                appPath = "";

            var sOut = Protocol + context.Request.ServerVariables["SERVER_NAME"] + Port + appPath;
            return sOut;

        }

        public static string CDNImage(this UrlHelper helper, string subfolder, string fileName)
        {
            string baseUrl = ConfigurationManager.AppSettings["ImageBaseUrl"];
            if (subfolder.StartsWith("/")) { subfolder = subfolder.Substring(1); }
            string imageUrl = baseUrl + "/" + subfolder + "/" + fileName;
            return imageUrl;
        }

        public static string CDNMissingStaffAvatarImage(this UrlHelper helper)
        {
            string baseUrl = ConfigurationManager.AppSettings["ImageBaseUrl"];
            return baseUrl + "/staff/missing-avatar.jpg";
            
        }

        public static string CDNMissingStaffLargeImage(this UrlHelper helper)
        {
            string baseUrl = ConfigurationManager.AppSettings["ImageBaseUrl"];
            return baseUrl + "/staff/missing-large.png";            
        }


        public static string SiteRoot(this UrlHelper url) {
            return SiteRoot(url.RequestContext.HttpContext);
        }


        public static string SiteRoot(this ViewPage pg) {
            return SiteRoot(pg.ViewContext.HttpContext);
        }

        public static string SiteRoot(this ViewUserControl pg) {
            var vpage = pg.Page as ViewPage;
            return SiteRoot(vpage.ViewContext.HttpContext);
        }

        public static string SiteRoot(this ViewMasterPage pg) {
            return SiteRoot(pg.ViewContext.HttpContext);
        }

        public static string GetReturnUrl(HttpContextBase context) {
            var returnUrl = "";

            if (context.Request.QueryString["ReturnUrl"] != null) {
                returnUrl = context.Request.QueryString["ReturnUrl"];
            }

            return returnUrl;
        }

        public static string GetReturnUrl(this UrlHelper helper) {
            return GetReturnUrl(helper.RequestContext.HttpContext);
        }

        public static string GetReturnUrl(this ViewPage pg) {
            return GetReturnUrl(pg.ViewContext.HttpContext);
        }

        public static string GetReturnUrl(this ViewMasterPage pg) {
            return GetReturnUrl(pg.Page as ViewPage);
        }

        public static string GetReturnUrl(this ViewUserControl pg) {
            return GetReturnUrl(pg.Page as ViewPage);
        }

    }
}
