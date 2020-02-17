using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Meek.Moe.ResponseEntities
{
    public class MeekMoeResponse
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("creator")]
        public string Creator { get; set; }
    }
}
