﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;

namespace Habitat.Framework.Search
{
    public class Templates
    {
        public struct SearchResult
        {
            public static ID ID = new ID("{14E452CA-064D-48A8-9FF2-2744D10437A1}");

            public struct Fields
            {
                public static readonly ID SearchBoxTitle = new ID("{80E30DD8-8021-45F5-9FE1-23D2702CC206}");
            }
        }
    }
}
