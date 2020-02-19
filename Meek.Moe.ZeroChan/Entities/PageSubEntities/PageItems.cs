using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meek.Moe.ZeroChan.Entities.PageSubEntities
{
    public class PageItems
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }
        [JsonPropertyName("@type")]
        public string Type { get; set; }
        [JsonPropertyName("itemListElement")]
        public List<Itemlistelement> ItemListElement { get; set; }

        public class Itemlistelement
        {
            [JsonPropertyName("@type")]
            public List<string> Type { get; set; }
            [JsonPropertyName("position")]
            public string Position { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("url")]
            public string Url { get; set; }
            [JsonPropertyName("thumbnailUrl")]
            public string ThumbnailUrl { get; set; }
        }

    }
}
