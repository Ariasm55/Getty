using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Collective.Library
{
   public class CheckLock
    {
       

public static bool SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
{
    Console.WriteLine(e.Reason.ToString());
    
    return false;
}

    }
}
