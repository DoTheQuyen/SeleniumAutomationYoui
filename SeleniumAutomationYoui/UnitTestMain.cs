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
        /// <summary>
        /// Initial setup global variables for NUnit system when start testing
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Finalise function when system finish all testcases
        /// </summary>
        [TearDown]
        public void Finalise()
        {

        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }
    }
}