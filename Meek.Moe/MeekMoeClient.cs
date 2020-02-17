using Meek.Moe.Enums;
using Meek.Moe.ResponseEntities;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Meek.Moe
{
    public class MeekMoeClient
    {
        HttpClient _client { get; set; }

        /// <summary>
        /// Create a client instance.
        /// Do NOT instanciate this multiple times.
        /// If you really need to use the other constructor and use your own HttpClient
        /// </summary>
        public MeekMoeClient()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Create a client instance with your custom HttpClient.
        /// </summary>
        /// <param name="client"></param>
        public MeekMoeClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<MeekMoeResponse> GetRandomImage(Endpoints endpoint)
        {
            Type enumType = typeof(Endpoints);
            MemberInfo[] memberInfos = enumType.GetMember(endpoint.ToString());
            MemberInfo enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            object[] valueAttributes = enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string description = ((DescriptionAttribute)valueAttributes[0]).Description;
            string response = await _client.GetStringAsync("https://api.meek.moe" + description);
            MeekMoeResponse result = JsonSerializer.Deserialize<MeekMoeResponse>(response);
            return result;
        }
    }
}
