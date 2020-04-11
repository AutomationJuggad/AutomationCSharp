using System;
using System.Configuration;
using System.IO;
namespace Selenium.Automation_Accelarator.Utilities
{
    public class ReadConfig
    {
        public static string fngetChromeDriverPath()
        {
            var strValue = "";
            try
            {
                var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                strValue = Path.Combine(projectFolder, @"Automation_Accelarator\Config\Lib\chromedriver.exe");
            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            return strValue;
        }

        public static string fnReadTestEngineConfig(string strConfigFile,string strConfig)
        {
            var strValue = "";
            try
            {
                ExeConfigurationFileMap customConfigFileMap = new ExeConfigurationFileMap();
                customConfigFileMap.ExeConfigFilename = strConfigFile;
                Configuration customConfig = ConfigurationManager.OpenMappedExeConfiguration(customConfigFileMap, ConfigurationUserLevel.None);
                KeyValueConfigurationCollection confCollection = customConfig.AppSettings.Settings;
                strValue = confCollection[strConfig].Value;

            }
            catch (Exception e) { Console.WriteLine(e.StackTrace); }
            return strValue;
        }
    }
}
