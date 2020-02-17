using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meek.Moe.Weeb.Sh.ResponseEntities.ImageAPI_toph.Get
{
    public class ImageTypes
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("types")]
        public List<string> Types { get; set; }
        [JsonPropertyName("preview")]
        public List<PreviewObject> Preview { get; set; }

        public class PreviewObject
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("fileType")]
            public string FileType { get; set; }
            [JsonPropertyName("baseType")]
            public string BaseType { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

    }
}
