using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class JsonUtils
{
    public static Rootobject GetDepartments()
    {
        // Making a call to our GetTweets Endpoint by employing a 
        // WebClient!
        var client = new WebClient();

        // Requesting JSON from the Web Server - because we have 
        //deserializer for JSON in place
        client.Headers.Add("Accept", "application/json");
        
        // Using WebClient we can download a file, a string etc.. 
        // we will downlaod String because we will be receving 
        // the data from our TweetService.svc in XML format or JSON format
        // ...all we have to do than is create a deserializer to create 
        // a object from that received XML/JSON data! .. sweet

        // to download a string we need to give the web address of our 
        // service endpoint below I have specified the local address 
        // and the correct endpoint to access the required information
        //var result = client.DownloadString
        //    ("http://120.24.214.43:8089/SmartBedService.svc/GetAllDepartments/2014-01-01");

        // Now we will employ the JSON desiralizer that comes with .NET 
        // to deserialize and create a Tweet object for us from the response 
        // received from TweetService.svc
        var serializer = new DataContractJsonSerializer(typeof(Rootobject)); 
        //using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(result)))
        //{

        //    Rootobject resultObject = serializer.ReadObject(stream) as Rootobject;

        //    return resultObject;
        //}
        string link = "http://120.24.214.43:8089/SmartBedService.svc/GetAllDepartments/2014-01-01";
        var request = (HttpWebRequest)WebRequest.Create(new Uri(link));
        request.ContentType = "application/json";
        request.Method = "GET";

        //using (var requestStream =   request.GetRequestStream())
        //{
        //    var writer = new StreamWriter(requestStream);
        //    writer.Write(data);
        //    writer.Flush();
        //}

        using (var resp = request.GetResponse())
        {
            using (var responseStream = resp.GetResponseStream())
            {
                var reader = new StreamReader(responseStream);
                var result = reader.ReadToEnd();
                var a = serializer.ReadObject(responseStream) ;
                return a as Rootobject;
            }
        }
    }
}
