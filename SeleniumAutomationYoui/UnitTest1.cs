using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumAutomationYoui
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}