using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SeleniumAutomationYoui.Report
{
    class Report
    {
        /// <summary>
        /// Declare global extent report.
        /// </summary>
        private static ExtentHtmlReporter reporter = new ExtentHtmlReporter("TestYoui.html");
        private static ExtentReports extReport = new ExtentReports();
        private static ExtentTest testcase;

        /// <summary>
        /// Init Report file.
        /// </summary>
        public static void InitReport()
        {
            extReport.AttachReporter(reporter);
            extReport.AddSystemInfo("OS: ", Environment.OSVersion.ToString());
            extReport.AddSystemInfo("Host Name: ", Dns.GetHostName());
            extReport.AddSystemInfo("Browser: ", "Google Chrome");
        }

        /// <summary>
        /// Function to create new test case for each test.
        /// </summary>
        /// <param name="name"></param>
        public static void NewTestCase(string name) => testcase = extReport.CreateTest(name);
     
        /// <summary>
        /// Function to write log step in each testcase
        /// </summary>
        /// <param name="status">status of log: 0 for step information, 1 for step pass, 2 for step fail</param>
        /// <param name="log">message log to be displayed in report</param>
        public static void WriteLog(int status, string log)
        {
            switch (status)
            {
                case 0://0 is for log info data only
                    testcase.Log(Status.Info, "Step: " + log);
                    goto default;
                case 1://1 is for log pass data only
                    testcase.Log(Status.Pass, "Step: " + log);
                    goto default;
                case 2://2 is for log fail data only
                    testcase.Log(Status.Fail, "Step: " + log);
                    goto default;

                default:
                    break;
            }
        }

        /// <summary>
        /// Function to finalise report and save.
        /// </summary>
        public static void CompleteReport() => extReport.Flush();
    }
}
