using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using Xx.His.Contract.Message;
using System.ServiceModel.Web;

namespace ApiUnitTestProject
{  
    /// <summary>
    /// https://www.codeproject.com/articles/386956/restful-wcf-json-service-with-client-and-on-mozill
    /// http://blog.csdn.net/fangxing80/article/details/6324642
    /// </summary>
    public class Client
    {
        public static TResult GetData<TResult>(string url) where TResult : class, new()
        {
            try
            {
                var request = GetRequest(url, "GET");
                var stream = request.GetResponse().GetResponseStream();

                var serializer = new DataContractJsonSerializer(typeof(TResult));
                var result = (TResult)serializer.ReadObject(stream);

                return result;
            }
            catch (WebException ex)
            {
                var errResp = ex.Response as HttpWebResponse;
                Console.WriteLine("StatusCode:{0}({1})", errResp.StatusCode, (int)errResp.StatusCode);
                using (var stream = errResp.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        Console.WriteLine("Content:{0}", sr.ReadToEnd());
                    }
                }
                throw;
            }
        }

        private static System.Net.WebRequest GetRequest(string url, string method)
        {
            if (url == null || url.Trim().Length == 0)
                throw new ArgumentNullException("服务地址为空，参数：url");

            var request = System.Net.WebRequest.Create(url);
            if (method != null && method.Trim().Length > 0)
                request.Method = method;

            return request;
        }

        public static TResult DownloadData<TResult>(string url) where TResult : class, new()
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] bytes = webClient.DownloadData(url);
                Stream steam = new MemoryStream(bytes);
                var serializer = new DataContractJsonSerializer(typeof(TResult));
                var result = (TResult)serializer.ReadObject(steam);
                return result;
            }
            catch (WebException ex)
            {
                var errResp = ex.Response as HttpWebResponse;
                Console.WriteLine("StatusCode:{0}({1})", errResp.StatusCode, (int)errResp.StatusCode);
                using (var stream = errResp.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        Console.WriteLine("Content:{0}", sr.ReadToEnd());
                    }
                }
                throw;
            }
        }
    }
}
