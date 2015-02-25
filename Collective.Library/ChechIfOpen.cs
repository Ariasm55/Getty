using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collective.Library
{
    public class ChechIfOpen
    {
        public static bool IsiitAlive()
        {
            var pname = Process.GetProcessesByName("Launcher");

            switch (pname.Length)
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }
    }
}
