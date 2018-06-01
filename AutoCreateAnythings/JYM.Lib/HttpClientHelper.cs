using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JYM.Lib
{
    public class HttpClientHelper
    {
        /// <summary>
        ///     client instance
        /// </summary>
        public static readonly Lazy<HttpClient> Client = new Lazy<HttpClient>(() => CreateClient());

        /// <summary>
        ///     获取httclient对象
        /// </summary>
        public static HttpClient GetHttpClient => Client.Value;

        /// <summary>
        ///     初始化一个对象
        /// </summary>
        /// <returns></returns>
        private static HttpClient CreateClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression =
                    DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Accept-Charset", "utf-8");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate,sdch");
            client.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.8");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.5));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.1));
            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");
            client.DefaultRequestHeaders.Add("X-JYM-Authorization", "Bearer ==");
            return client;
        }
    }
}