using Automation.Automation_Accelarator.Config;
using Automation.Automation_Accelarator.Reports;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using Selenium.Automation_Accelarator.Utilities;
using System;
using System.Threading;

namespace Automation.Automation_Accelarator.Accelarrator
{
    [TestFixture]
    public class TestEngine:Reporter
    {
        public RemoteWebDriver driver = null;
        public TestConfig objConfig = null;
        AppiumLocalService service = null;
        /// <summary>
        /// Function Name :- OneTimeSetUp
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            objConfig = TestConfig.FnLoadTestConfig();
            Reporter.FnCreateExtentReport();
        }
        /// <summary>
        /// Function Name :- OneTimeTearDown
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Reporter.FnCloseExtentReport();
        }
        /// <summary>
        /// Function Name :- Setup
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        [SetUp]
        public void Setup()
        {
           string strFeatureName = this.GetType().Name;
           string strTestName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
           Reporter.FnCreateExtentTest(strTestName, "Verifying " + strFeatureName + " : " + strTestName);
           FnGetDriver();
        }
        /// <summary>
        /// Function Name :- TearDown
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("After Test ==> Tear Down");
            if(driver!=null)
            {
                driver.Close();
            }
        }

        /// <summary>
        /// Function Name :- FnGetDriver
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public void FnGetDriver()
        {
            try
            {
                if(GeneralUtil.FnVerifyText(objConfig.OS,"win"))
                {
                    if (GeneralUtil.FnVerifyText(objConfig.AppType, "web"))
                    {
                        if (GeneralUtil.FnVerifyText(objConfig.Browser, "chrome"))
                        {
                            ChromeOptions chromeopt = new ChromeOptions();
                            chromeopt.AddArgument("incognito");
                            chromeopt.AcceptInsecureCertificates = true;
                            driver = new ChromeDriver(chromeopt);
                        }
                        else if (GeneralUtil.FnVerifyText(objConfig.Browser, "firefox"))
                        {
                            driver = new FirefoxDriver();
                        }
                        else if (GeneralUtil.FnVerifyText(objConfig.Browser, "ie"))
                        {
                            driver = new InternetExplorerDriver();
                        }
                        if (driver != null)
                            driver.Manage().Window.Maximize();

                    }
                    else if (GeneralUtil.FnVerifyText(objConfig.AppType, "app"))
                    {
                        if (GeneralUtil.FnVerifyText(objConfig.Browser, "androidchrome"))
                        {
                            FnStartAppiumServer();
                            AppiumOptions options = new AppiumOptions();
                            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                            options.AddAdditionalCapability(MobileCapabilityType.BrowserName, MobileBrowserType.Chrome);
                            options.AddAdditionalCapability("chromedriverExecutable", ReadConfig.FngetChromeDriverPath().ToString());
                            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, objConfig.DeviceOSVersion);
                            options.AddAdditionalCapability("deviceName", objConfig.DeviceName);
                            options.AddAdditionalCapability("–session-override", true);
                            driver = new AndroidDriver<AndroidElement>(new Uri(objConfig.AppiumURL),options);
                            Thread.Sleep(10000);
                        }
                        else
                        {
                            FnStartAppiumServer();
                            AppiumOptions options = new AppiumOptions();
                            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "android");
                            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, objConfig.DeviceOSVersion);
                            options.AddAdditionalCapability("deviceName", objConfig.DeviceName);
                            options.AddAdditionalCapability("–session-override", true);
                            options.AddAdditionalCapability("appPackage", objConfig.AppPackage);
                            options.AddAdditionalCapability("appActivity", objConfig.AppActivity);
                            driver = new AndroidDriver<AndroidElement>(new Uri(objConfig.AppiumURL), options);
                            Thread.Sleep(10000);

                        }
                    }
                }
                else if (GeneralUtil.FnVerifyText(objConfig.OS, "mac"))
                {
                    if (GeneralUtil.FnVerifyText(objConfig.AppType, "web"))
                    {
                        if (GeneralUtil.FnVerifyText(objConfig.Browser, "chrome"))
                        {

                        }
                        else if (GeneralUtil.FnVerifyText(objConfig.Browser, "firefox"))
                        {

                        }
                    }
                    else if (GeneralUtil.FnVerifyText(objConfig.AppType, "app"))
                    {

                    }
                }
                if (driver != null)
                    driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(60);
            }
            catch (Exception e) { Reporter.Fail("Unable to Get the Driver " + e.StackTrace); }
        }
        /// <summary>
        /// Function Name :- FnStopAppiumServer
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public bool FnStopAppiumServer()
        {
            bool blnStatus = true;
            try
            {
                if (service != null)
                {
                    service.Dispose();
                }
            }
            catch (Exception e)
            {
                blnStatus = false;
                Console.WriteLine(e.StackTrace);
            }
            return blnStatus;
        }
        /// <summary>
        /// Function Name :- FnStartAppiumServer
        /// Created By :- Pankaj Kumar
        /// Date of Creation :- 11-Apr-2020
        /// </summary>
        public bool FnStartAppiumServer()
        {
            bool blnStatus = true;
            try
            {
                OptionCollector args = new OptionCollector().AddArguments(GeneralOptionList.LogNoColors());
                Environment.SetEnvironmentVariable(AppiumServiceConstants.NodeBinaryPath,objConfig.NodeBinaryPath);
                Environment.SetEnvironmentVariable(AppiumServiceConstants.AppiumBinaryPath, objConfig.AppiumBinaryPath);
                service = new AppiumServiceBuilder().UsingPort(4723).WithArguments(args).Build();
                service.Start();
                Console.WriteLine("Appium Server Started at ==> " + service.ServiceUrl);
            }
            catch (Exception e)
            {
                blnStatus = false;
                Console.WriteLine(e.StackTrace);
            }
            return blnStatus;
        }
    }
}
