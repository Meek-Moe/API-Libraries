using Meek.Moe.ZeroChan.Entities;
using Meek.Moe.ZeroChan.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Meek.Moe.ZeroChan
{
    public class ZeroChanClient
    {
        HttpClient _client { get; set; }

        string _username { get; set; }
        string _password { get; set; }

        /// <summary>
        /// Create a client instance.
        /// Do NOT instanciate this multiple times.
        /// If you really need to use the other constructor and use your own HttpClient
        /// </summary>
        public ZeroChanClient(string username, string password)
        {
            _username = username;
            _password = password;
            _client = new HttpClient();
        }

        /// <summary>
        /// Create a client instance with your custom HttpClient.
        /// </summary>
        /// <param name="client"></param>
        public ZeroChanClient(string username, string password, HttpClient client)
        {
            _username = username;
            _password = password;
            _client = client;
        }

        public async Task LoginAsync()
        {
            FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("ref", "/"),
                new KeyValuePair<string, string>("name", _username),
                new KeyValuePair<string, string>("password", _password),
                new KeyValuePair<string, string>("login", "Anmeldung")
            });
            HttpResponseMessage hm = await _client.PostAsync("https://www.zerochan.net/login", content);
            
        }

        public async Task<PageMain> GetByTagSortedByPage(string tag, int page = 1)
        {
            if (page < 1) page = 1;
            tag = Uri.EscapeDataString(tag);
            string content = await _client.GetStringAsync("https://www.zerochan.net/" + tag + "?p=" + page);
            PageMain items = PageJsonParser.ParseSearchQueryPageWithPageCount(content);
            return items;
        }



        public async Task<PageMain> GetByTagSortedByID(string tag, int id = 0)
        {
            if (id < 0) id = 0;
            tag = Uri.EscapeDataString(tag);
            string content = await _client.GetStringAsync("https://www.zerochan.net/" + tag + "?o=" + id);
            PageMain items = PageJsonParser.ParseSearchQueryPageWithID(content);
            return items;
        }
    }
}
