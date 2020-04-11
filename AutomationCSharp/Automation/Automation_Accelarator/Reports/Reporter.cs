using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Selenium.Automation_Accelarator.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Automation_Accelarator.Reports
{
    public class Reporter
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        /// <summary>
        /// Function Name :- fnCreateExtentReport
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void fnCreateExtentReport()
        {
            try
            {
                string strGlobalConfigFile = GeneralUtil.fnGetProjectFolder() + @"Automation_Accelarator\Config\Global.config";
                ExtentHtmlReporter htmlReporter = fnSetConfigDetails();
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                extent.AddSystemInfo("Environment", ReadConfig.fnReadTestEngineConfig(strGlobalConfigFile, "Environment"));
                extent.AddSystemInfo("User Name", GeneralUtil.fnGetHostName());
                extent.AddSystemInfo("IP Address", GeneralUtil.fnGetIPAddress());
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }

        }
        /// <summary>
        /// Function Name :- fnCloseExtentReport
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void fnCloseExtentReport()
        {
            extent.Flush();
        }
        /// <summary>
        /// Function Name :- fnCreateExtentTest
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void fnCreateExtentTest(string strTestName,string strTestDescription)
        {
            test = extent.CreateTest(strTestName, strTestDescription);
        }
        /// <summary>
        /// Function Name :- Pass
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void Pass(string strDescription)
        {
            try
            {
                test.Pass(strDescription);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace);}           
        }
        /// <summary>
        /// Function Name :- Fail
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void Fail(string strDescription)
        {
            try
            {
                test.Fail(strDescription);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
        /// <summary>
        /// Function Name :- Info
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void Info(string strDescription)
        {
            try
            {
                test.Info(strDescription);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
        /// <summary>
        /// Function Name :- Skip
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void Skip(string strDescription)
        {
            try
            {
                test.Skip(strDescription);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
        /// <summary>
        /// Function Name :- Fatal
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static void Fatal(string strDescription)
        {
            try
            {
                test.Fatal(strDescription);
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
        }
        /// <summary>
        /// Function Name :- fnSetConfigDetails
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static ExtentHtmlReporter fnSetConfigDetails()
        {
            ExtentHtmlReporter htmlReporter = null;
            try
            {
                string strGlobalConfigFile = GeneralUtil.fnGetProjectFolder() + @"Automation_Accelarator\Config\Global.config";
                var strReportFolder = GeneralUtil.fnGetProjectFolder() + @"Test\TestReports\CurrentReport\";
                htmlReporter = new ExtentHtmlReporter(strReportFolder);
                htmlReporter.Config.Theme = Theme.Dark;
                htmlReporter.Config.DocumentTitle = ReadConfig.fnReadTestEngineConfig(strGlobalConfigFile, "DocumentTitle");
                htmlReporter.Config.ReportName = ReadConfig.fnReadTestEngineConfig(strGlobalConfigFile, "ReportName");
                htmlReporter.Config.Encoding = "UTF-8";
                            
            }
            catch (Exception e)
            {
                Console.WriteLine( e.StackTrace);
            }
            return htmlReporter;
        }
        
    }
}
