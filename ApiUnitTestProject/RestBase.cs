using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Net;
using log4net;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using Mellson.WebService.Client.DAL;
using Mellson.WebService.Client.Configuration;
using Mellson.WebService.Client.Domain;
using Mellson.WebService.Client.Utils;

namespace Mellson.WebService.Client
{
    public class RestBase
    {
        static ILog logger = log4net.LogManager.GetLogger(typeof(RestBase));
     
        protected DateTime startDate;
        protected DateTime endDate;

        #region 服务请求类型
        public enum RequestType
        {
            Sale,
            Voucher,
            Unknow,
        }
        #endregion
 
        public static T Serialization<T>(string jsonStr)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(jsonStr);
        }
 
        protected string PullJsonDataFromUri(string uri)
        {
            HttpWebResponse response = null;

            if (uri == null)
                throw new ArgumentNullException("uri");           

            try
            {
                string contents = "";

                Uri address = new Uri(uri);

                logger.Info(string.Format(" Send request to uri: {0}", uri));

                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                request.Method = "GET";                
                request.KeepAlive = true;
                request.Timeout = 30 * 1000;
                AuthenticationConfigElement authentication = ServiceConfigGroup.WebServiceSettings.AuthenticationElement;
                request.Credentials = new NetworkCredential(authentication.UserName, authentication.Password);

                var st = new System.Diagnostics.Stopwatch();
                st.Start();
                response = request.GetResponse() as HttpWebResponse;
                st.Stop();

                logger.Info(string.Format(" 用时 {0} 秒", st.Elapsed.TotalSeconds));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        contents = reader.ReadToEnd();
                    }
                }
                else
                {
                    logger.Error(" No Response.");
                }

                return contents;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (response != null) response.Close();             
            }
        }       

        protected string CreateFormattedPostRequest(string baseUri, IDictionary<string, string> parameters)
        {
            string formattedPostRequest = "";

            if (parameters != null)
            {
                var counter = 0;
                var paramterBuilder = new StringBuilder();

                foreach (var parameter in parameters)
                {
                    if (counter == 0) 
                    {
                        paramterBuilder.AppendFormat("{0}={1}", "datetime_begin", ConvertUtils.ToInt(startDate).ToString());
                        paramterBuilder.AppendFormat("&");
                        paramterBuilder.AppendFormat("{0}={1}", "datetime_end", ConvertUtils.ToInt(endDate).ToString());
                        paramterBuilder.AppendFormat("&");
                    }

                    paramterBuilder.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
                    if (counter != parameters.Count - 1)
                    {
                        paramterBuilder.Append("&");
                    }

                    counter++;
                }

                formattedPostRequest = paramterBuilder.ToString();
            }

            return (formattedPostRequest == "") ? baseUri : string.Format("{0}?{1}", baseUri, formattedPostRequest); 

        }

        protected RequestType Map2RequestType(string workName) 
        {
            RequestType requestType;

            if (workName == "销售订单")
            {
                requestType = RestClient.RequestType.Sale;
            }
            else if (workName == "出入库单据")
            {
                requestType = RestClient.RequestType.Voucher;
            }
            else 
            {
                requestType = RequestType.Unknow;
            }

            return requestType;
        }
    }
}
