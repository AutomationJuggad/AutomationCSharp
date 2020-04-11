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
        /// <summary>
        /// Function Name :- fnGetHostName
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string fnGetHostName()
        {
            string hostName = Dns.GetHostName();
            return hostName;
        }
        /// <summary>
        /// Function Name :- fnGetIPAddress
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string fnGetIPAddress()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }
        /// <summary>
        /// Function Name :- fnGetProjectFolder
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string fnGetProjectFolder()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }
        /// <summary>
        /// Function Name :- fnCopyFolder
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
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
        /// <summary>
        /// Function Name :- fnVerifyText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static Boolean fnVerifyText(string strText1,string strText2)
        {
            Boolean blnStatus = true;
            try
            {
                if (strText1.ToLower().Equals(strText2.ToLower()))
                    blnStatus = true;
                else
                    blnStatus = false;
            }
            catch (Exception e) { blnStatus = false; }
            return blnStatus;
        }
    }
}
