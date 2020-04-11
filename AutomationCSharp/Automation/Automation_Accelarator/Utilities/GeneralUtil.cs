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
        /// Function Name :- FnGetHostName
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string FnGetHostName()
        {
            string hostName = Dns.GetHostName();
            return hostName;
        }
        /// <summary>
        /// Function Name :- FnGetIPAddress
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string FnGetIPAddress()
        {
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            return myIP;
        }
        /// <summary>
        /// Function Name :- FnGetProjectFolder
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static string FnGetProjectFolder()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }
        /// <summary>
        /// Function Name :- FnCopyFolder
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static Boolean FnCopyFolder(string strReootFolder,string strDestinationFolder)
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
        /// Function Name :- FnVerifyText
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static Boolean FnVerifyText(string strText1,string strText2)
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
