using System;
using System.Net.Http;

namespace Meek.Moe.Weeb.Sh
{
    public class WeebShClient
    {
        HttpClient _client { get; set; }

        string _token { get; set; }

        /// <summary>
        /// Create a client instance.
        /// Do NOT instanciate this multiple times.
        /// If you really need to use the other constructor and use your own HttpClient
        /// </summary>
        public WeebShClient(string token)
        {
            _token = token;
            _client = new HttpClient();
        }

        /// <summary>
        /// Create a client instance with your custom HttpClient.
        /// </summary>
        /// <param name="client"></param>
        public WeebShClient(string token, HttpClient client)
        {
            _token = token;
            _client = client;
        }


    }
}
