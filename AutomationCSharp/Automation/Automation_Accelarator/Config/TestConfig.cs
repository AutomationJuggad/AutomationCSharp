using Automation.Automation_Accelarator.Reports;
using Selenium.Automation_Accelarator.Utilities;
using System;

namespace Automation.Automation_Accelarator.Config
{
    public class TestConfig
    {
        public string strTestConfigFile = null;
        public string AppType = null;
        public string Browser = null;
        public string OS = null;
        public string DeviceName = null;
        public string DeviceOSVersion = null;
        public string AppPackage = null;
        public string AppActivity = null;
        public string AppiumURL = null;
        public string Environment = null;
        public string NodeBinaryPath = null;
        public string AppiumBinaryPath = null;
        /// <summary>
        /// Function Name :- FnLoadTestConfig
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static TestConfig FnLoadTestConfig()
        {
            TestConfig testConfig = new TestConfig();
            try
            {
                string strTestConfigFile = GeneralUtil.FnGetProjectFolder() + @"Automation_Accelarator\Config\TestConfig.config";
                testConfig.AppType = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "AppType");
                testConfig.Browser = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "Browser");
                testConfig.OS = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "OS");
                testConfig.DeviceName = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "DeviceName");
                testConfig.DeviceOSVersion = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "DeviceOSVersion");
                testConfig.AppPackage = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "AppPackage");
                testConfig.AppActivity = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "AppActivity");
                testConfig.AppiumURL = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "AppiumURL");
                testConfig.Environment = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "Environment");
                testConfig.NodeBinaryPath = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "NodeBinaryPath");
                testConfig.AppiumBinaryPath = ReadConfig.FnReadTestEngineConfig(strTestConfigFile, "AppiumBinaryPath");
            }
            catch (Exception e) { Reporter.Fail("Unable to Get the Driver " + e.StackTrace); }
            
            
        return testConfig;
    }
    }
}
