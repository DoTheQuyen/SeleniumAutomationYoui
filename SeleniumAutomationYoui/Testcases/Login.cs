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

namespace SeleniumAutomationYoui.Testcases
{
    class Login
    {
        /// <summary>
        /// reference global variables
        /// </summary>
        private static IWebDriver driver => Tests.GetDriver();
        private static string url => Tests.GetUrl();


       /// <summary>
       /// Function to login user created
       /// </summary>
       /// <param name="email">email address to login</param>
       /// <param name="pwd">password to login user</param>
        public void LoginUser(string email, string pwd)
        {
            //write log new testcase
            Report.Report.NewTestCase("Login user testcase.");

            try
            {
                // step 1: Load page, and find login href
                Report.Report.WriteLog(0, "Open Demo Web Shop successfully. Start locating Login href");
                driver.FindElement(By.ClassName("ico-login")).Click();
                Report.Report.WriteLog(1, "Located Login button. Perform click action to redirect to login page.");
                //wait up to 10 seconds for page to redirect
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                //step 2: Fill in email
                driver.FindElement(By.Id("Email")).SendKeys(email);
                Report.Report.WriteLog(1, "Filled in email name: " + email);

                //step 3: Fill in password
                driver.FindElement(By.Id("Password")).SendKeys(pwd);
                Report.Report.WriteLog(1, "Filled in password");

                //step 3: Click Login button
                driver.FindElement(By.ClassName("login-button")).Click();
                Report.Report.WriteLog(1, "Clicked Login button to log user in");
                //wait for up to 20 seconds to return result
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                //step 4: Expect some books result.
                var result = driver.FindElement(By.ClassName("ico-logout")).Displayed;
                if (result)
                    Report.Report.WriteLog(1, "Login completed. User is logged in.");
                else
                    Report.Report.WriteLog(1, "Login completed. User can not login.");

                Report.Report.WriteLog(1, "Testcase completed.");

            }
            catch (NotFoundException nEx)
            {
                Report.Report.WriteLog(2, "Test case can not locate element at " + nEx);
            }
            catch (TimeoutException tEx)
            {
                Report.Report.WriteLog(2, "Test case timeout at " + tEx);
            }
            catch (Exception ex)
            {
                Report.Report.WriteLog(2, "Test case failed at " + ex);
            }
        }

        /// <summary>
        /// Function to Log out user
        /// </summary>
        public void LogoutUser()
        {
            //write log new testcase
            Report.Report.NewTestCase("Logout user testcase.");

            try
            {
                // step 1: Load page, and find login href
                Report.Report.WriteLog(0, "Open Demo Web Shop successfully. Start locating Login href");
                driver.FindElement(By.ClassName("ico-logout")).Click();
                Report.Report.WriteLog(1, "Located Login button. Perform click action to redirect to login page.");
                //wait up to 10 seconds for page to redirect
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                Report.Report.WriteLog(1, "Testcase completed.");

            }
            catch (NotFoundException nEx)
            {
                Report.Report.WriteLog(2, "Test case can not locate element at " + nEx);
            }
            catch (TimeoutException tEx)
            {
                Report.Report.WriteLog(2, "Test case timeout at " + tEx);
            }
            catch (Exception ex)
            {
                Report.Report.WriteLog(2, "Test case failed at " + ex);
            }
        }
    }
}
