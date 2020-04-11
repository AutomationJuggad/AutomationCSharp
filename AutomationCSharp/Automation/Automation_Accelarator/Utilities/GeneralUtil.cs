using Automation.Automation_Accelarator.Accelarrator;
using Automation.Automation_Accelarator.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace Selenium.Automation_Accelarator.Utilities
{
    public class GeneralUtil:TestEngine
    {
        public static string fnGetHostName()
        {
            string hostName = Dns.GetHostName();
            return hostName;
        }

        public static string fnGetIPAddress()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }

        public static string fnGetProjectFolder()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }

        public static Boolean fnCopyFolder(string strReootFolder,string strDestinationFolder)
        {
            Boolean blnStatus = true;
            try
            {

            }
            catch (Exception e)
            {
                blnStatus = false;
                Reporter.Fail("Error Eoocured :- " + e.StackTrace);
                
            }
            return blnStatus;
        }

    }
}
