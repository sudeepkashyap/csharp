using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;
using Microsoft.Msn.Set.Web;
using Microsoft.Msn.Set.Web.Data;

namespace MyHandler
{
    public class SyncHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        private static readonly string CHECKCACHETEXT = @"<currentTime value='{0}'>{1}</currentTime>";

        public void ProcessRequest(HttpContext context)
        {
            showAllCacheKeys(context);
        }

        #region

        private void showAllCacheKeys(HttpContext context)
        {
            StringBuilder strb = new StringBuilder("<keys>");
            foreach (DictionaryEntry cacheItem in System.Web.HttpRuntime.Cache)
            {
                var timespan = String.Empty;
                var cachevalue = String.Empty;
                if (cacheItem.Value is CacheItem)
                {
                    timespan = ((CacheItem)(cacheItem.Value)).Timestamp.ToString();
                    cachevalue = ((CacheItem)(cacheItem.Value)).Data.ToString();
                }
                strb.Append((String.Format("<CacheItem><timespan><![CDATA[{0}]]></timespan>", timespan)));
                strb.Append((String.Format("<key><![CDATA[{0}]]></key>", cacheItem.Key.ToString())));
                strb.Append((String.Format("<value><![CDATA[{0}]]></value></CacheItem>", cachevalue)));
            }
            strb.Append("</keys>");
            context.Response.ContentType = "text/xml";
            context.Response.Write(String.Format(CHECKCACHETEXT, DateTime.Now.ToString(), strb.ToString()));
        }

        #endregion
    }
}
