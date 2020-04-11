// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using Automation.Automation_Accelarator.Accelarrator;
using Automation.Automation_Accelarator.Reports;
using NUnit.Framework;

namespace Automation
{
    [TestFixture]
    public class Login:TestEngine
    {
        [Test]
        public void VerifyLoginWithPassword()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
            Reporter.Pass("Test Case 1");
            Reporter.Pass("Test Case 12");
            Reporter.Pass("Test Case 13");
            Reporter.Pass("Test Case 14");
            Reporter.Pass("Test Case 15");
        }
        [Test]
        public void VerifyLoginWithoutPassword()
        {
            // TODO: Add your test code here
            var answer = 42;
            Assert.That(answer, Is.EqualTo(42), "Some useful error message");
            Reporter.Pass("Test Case 1");
            Reporter.Fail("Test Case 12");
            Reporter.Pass("Test Case 13");
            Reporter.Fail("Test Case 14");
            Reporter.Pass("Test Case 15");
        }
    }
}
