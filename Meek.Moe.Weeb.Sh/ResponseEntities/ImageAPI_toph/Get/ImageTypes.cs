using System;
using System.Collections.Generic;
using System.Text;

namespace Meek.Moe.Weeb.Sh.ResponseEntities.ImageAPI_toph.Get
{
    public class ImageTypes
    {
            public int status { get; set; }
            public string[] types { get; set; }
            public Preview[] preview { get; set; }

        public class Preview
        {
            public string url { get; set; }
            public string id { get; set; }
            public string fileType { get; set; }
            public string baseType { get; set; }
            public string type { get; set; }
        }

    }
}
