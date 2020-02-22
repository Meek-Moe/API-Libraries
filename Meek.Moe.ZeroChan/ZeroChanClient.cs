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

        public async Task<TagResultsPageByPages> GetNewestByTagSortedByPage(string tag, int page = 1)
        {
            if (page < 1)
                throw new Exception("Page number cant be under 1");
            if (page > 100)
                throw new Exception("For pages higher than 100\n" +
                    "Use the Page to ID search Converter to get the 'next' page");
            tag = Uri.EscapeDataString(tag);
            string content = await _client.GetStringAsync("https://www.zerochan.net/" + tag + "?p=" + page);
            TagResultsPageByPages items = PageJsonParser.ParseSearchQueryPageWithPageCount(content, page);
            return items;
        }

        public async Task<TagResultsPageByID> GetNewestIDPageAfter100thPage(string tag)
        {
            tag = Uri.EscapeDataString(tag);
            string content = await _client.GetStringAsync("https://www.zerochan.net/" + tag + "?p=100");
            TagResultsPageByID items = PageJsonParser.ParseSearchQueryPageWithID(content, 100);
            return items;
        }

        public async Task<TagResultsPageByID> GetNewestByTagSortedByID(string tag, int id = 0)
        {
            if (id < 0)
                throw new Exception("ID cant be under 0");
            tag = Uri.EscapeDataString(tag);
            string content = await _client.GetStringAsync("https://www.zerochan.net/" + tag + "?o=" + id);
            TagResultsPageByID items = PageJsonParser.ParseSearchQueryPageWithID(content, id);
            return items;
        }

        public async Task<TagResultsPageByPages> GetUserGallery(string username, int page = 1)
        {
            if (page < 1)
                throw new Exception("Page number cant be under 1");
            username = Uri.EscapeDataString(username);
            string content = await _client.GetStringAsync("https://www.zerochan.net/user/" + username + "?p=" + page);
            TagResultsPageByPages items = PageJsonParser.ParseSearchQueryPageWithPageCount(content, page);
            return items;
        }
    }
}
