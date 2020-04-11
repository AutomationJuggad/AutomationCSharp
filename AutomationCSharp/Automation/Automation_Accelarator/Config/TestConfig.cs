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
        /// Function Name :- fnLoadTestConfig
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public static TestConfig fnLoadTestConfig()
        {
            TestConfig testConfig = new TestConfig();
            try
            {
                string strTestConfigFile = GeneralUtil.fnGetProjectFolder() + @"Automation_Accelarator\Config\TestConfig.config";
                testConfig.AppType = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "AppType");
                testConfig.Browser = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "Browser");
                testConfig.OS = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "OS");
                testConfig.DeviceName = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "DeviceName");
                testConfig.DeviceOSVersion = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "DeviceOSVersion");
                testConfig.AppPackage = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "AppPackage");
                testConfig.AppActivity = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "AppActivity");
                testConfig.AppiumURL = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "AppiumURL");
                testConfig.Environment = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "Environment");
                testConfig.NodeBinaryPath = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "NodeBinaryPath");
                testConfig.AppiumBinaryPath = ReadConfig.fnReadTestEngineConfig(strTestConfigFile, "AppiumBinaryPath");
            }
            catch (Exception e) { Reporter.Fail("Unable to Get the Driver " + e.StackTrace); }
            
            
        return testConfig;
    }
    }
}
