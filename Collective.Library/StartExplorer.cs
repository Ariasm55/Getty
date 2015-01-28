using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Collective.Library
{
    public class StartExplorer
    {
        public static void StartWindows()
        {

            //Process process = new Process();
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            //startInfo.FileName = "explorer.exe";
            //startInfo.Arguments = "";
            //process.StartInfo = startInfo;
            //process.Start();

            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\Windows\\explorer.exe";
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.WorkingDirectory = "C:\\";
            myProcess.StartInfo.CreateNoWindow = true;

            myProcess.Start();

            }
        }
    }

