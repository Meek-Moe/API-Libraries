using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meek.Moe.ZeroChan.Entities.PageSubEntities
{
    public class PageGeneralInfo
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
