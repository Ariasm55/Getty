﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Library
{
    public class GlobalVariables
    {
        public static class GlobalsLib
        {
            public static bool CheckLogin { get; set; }
            public static long RecordIdLogout { get; set; }
            public static long RecordIdPause { get; set; }
            public static bool CanClose { get; set; }
            public static string Usernamechat { get; set; }

            public static bool Sentmsg { get; set; }

            public static DateTime Timing { get; set; }
        }
    }
}
