using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using SeleniumAutomationYoui.Report;
using SeleniumAutomationYoui.Testcases;

namespace SeleniumAutomationYoui
{
    public class Tests
    {

        private static string url = "http://demowebshop.tricentis.com/";
        private static IWebDriver driver = new ChromeDriver();

        private string email;
        private string pwd;
        /// <summary>
        /// Initial setup global variables for NUnit system when start testing
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Report.Report.InitReport();
        }

        /// <summary>
        /// Finalise function when system finish all testcases
        /// </summary>
        [TearDown]
        public void Finalise()
        {
            //Finalise and save report
            Report.Report.CompleteReport();
            //Close chrome driver
            driver.Quit();
        }

        /// <summary>
        /// Function to point to initialized IWebDriver
        /// </summary>
        /// <returns></returns>
        public static IWebDriver GetDriver()
        {
            return driver;
        }

        /// <summary>
        /// Function to read initialised url
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return url;
        }


        [Test]
        public void FullTestSenario()
        {
            email = "testdemoyoui" + DateTime.Now.Ticks + "@gmail.com";
            pwd = "look4u";

            //Start register testcase
            var register = new Testcases.Register();            
            register.RegisterUser(1, "Quyen", "Do", email, pwd, pwd);

            //Start login testcase
            var login = new Testcases.Login();
            //After register new user. System will auto log user in. So, log user out first to try login case.
            login.LogoutUser();
            login.LoginUser(email, pwd);

            //Start search testcase
            var search = new Testcases.SearchBook();
            search.SearchBookName("Fiction");

        }
    }
}