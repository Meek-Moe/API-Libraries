﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Meek.Moe.ZeroChan.Entities
{
    public class TagResultsPageByPages : PageMain
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
