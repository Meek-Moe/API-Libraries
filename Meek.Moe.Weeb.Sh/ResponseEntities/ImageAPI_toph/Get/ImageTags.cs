using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Meek.Moe.Weeb.Sh.ResponseEntities.ImageAPI_toph.Get
{
    public class ImageTags
    {
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
