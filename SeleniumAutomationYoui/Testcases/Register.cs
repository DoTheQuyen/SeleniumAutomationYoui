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

namespace SeleniumAutomationYoui.Testcases
{
    class Register
    {
        /// <summary>
        /// reference global variables
        /// </summary>
        private static IWebDriver driver => Tests.GetDriver();
        private static string url => Tests.GetUrl();

        /// <summary>
        /// Init contructor with Chrome environment
        /// </summary>
        public Register()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Function to register a new user
        /// </summary>
        /// <param name="gender">gender of user: 1 for male, others for female</param>
        /// <param name="fname">first name of user</param>
        /// <param name="lname">last name of user</param>
        /// <param name="email">email to register. Add post-fix with time tick to auto generate new email address to prevent duplicate email and cant not register.</param>
        /// <param name="pwd">password of new user</param>
        /// <param name="confirmPwd">confirm password to verify</param>
        public void RegisterUser(int gender, string fname, string lname, string email, string pwd, string confirmPwd)
        {
            //write log new testcase
            Report.Report.NewTestCase("Register new user testcase.");

            try
            {
                // step 1: Load page, and find Register href
                Report.Report.WriteLog(0, "Open Demo Web Shop successfully. Start finding Register href.");

                //step 2: click on Register href to redirect to register page
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a")).Click();
                Report.Report.WriteLog(1, "Located Register button. Perform click action to redirect to registration page.");
                //wait up to 10 seconds for page to redirect
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Assert.That(driver.FindElement(By.ClassName("registration-page")).Displayed, Is.True);
                Report.Report.WriteLog(1, "Registration page loaded. Start registration");

                //step 3: Form load. Select gender
                if (gender == 1)
                    driver.FindElement(By.XPath("//*[@id='gender-male']")).Click();
                else
                    driver.FindElement(By.XPath("//*[@id='gender-female']")).Click();
                Report.Report.WriteLog(1, "Select gender checkbox");

                //step 4: Fill in first name
                driver.FindElement(By.Id("FirstName")).SendKeys(fname);
                Report.Report.WriteLog(1, "Filled in firt name: " + fname);

                //step 5: Fill in last name
                driver.FindElement(By.Id("LastName")).SendKeys(lname);
                Report.Report.WriteLog(1, "Filled in last name: " + lname);

                //step 6: Fill in email
                driver.FindElement(By.Id("Email")).SendKeys(email);
                Report.Report.WriteLog(1, "Filled in email name: " + email);

                //step 7: Fill in password
                driver.FindElement(By.Id("Password")).SendKeys(pwd);
                Report.Report.WriteLog(1, "Filled in password");

                //step 8: Fill in confirm password
                driver.FindElement(By.Id("ConfirmPassword")).SendKeys(confirmPwd);
                Report.Report.WriteLog(1, "Filled in confirm password");

                //step 9: Click register button
                driver.FindElement(By.Id("register-button")).Click();
                Report.Report.WriteLog(1, "Clicked register button to register user.");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Report.Report.WriteLog(1, "Registration completed. New user is created with email: " + email);

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
