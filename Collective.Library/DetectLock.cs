using System;

using Microsoft.Win32;

namespace Collective.Library
{
    public class DetectLock
    {
        public bool SysEventsCheck(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock: 
                    Console.WriteLine("Lock Encountered");
                    return true;
                case SessionSwitchReason.SessionUnlock: 
                    Console.WriteLine("UnLock Encountered");
                    return false;
                    
            }
            return false;
        }

        


      


    }
}
