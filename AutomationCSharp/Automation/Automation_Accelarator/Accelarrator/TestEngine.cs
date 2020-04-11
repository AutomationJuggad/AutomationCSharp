using Automation.Automation_Accelarator.Reports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Automation_Accelarator.Accelarrator
{
    [TestFixture]
    public class TestEngine:Reporter
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Reporter.fnCreateExtentReport();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Reporter.fnCloseExtentReport();
        }

        [SetUp]
        public void Setup()
        {
            string strFeatureName = this.GetType().Name;
            string strTestName = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            Reporter.fnCreateExtentTest(strTestName, "Verifying " + strFeatureName + " : " + strTestName);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("After Test ==> Tear Down");
        }
    }
}
