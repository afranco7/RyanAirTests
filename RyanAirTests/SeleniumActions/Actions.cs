using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanAirTests.SeleniumActions
{
    public class Actions
    {

        private int retryTime = 0;
        public static void GoToPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            VerifyPageCompleteState(driver);
        }

        public static void VerifyPageCompleteState(IWebDriver driver, double secondsToWait = 30)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch
            {
                throw new TimeoutException("after a " + secondsToWait + " second wait, the web page did not reach a complete state");
            }
        }

        public static void ClickOn(IWebDriver driver, IWebElement element, double secondsToWait = 20)
        {
            VerifyPageCompleteState(driver, secondsToWait);
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
            catch (Exception e)
            {
                try
                {
                    IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                    executor.ExecuteScript("arguments[0].click();", element);
                    VerifyPageCompleteState(driver, secondsToWait);
                }
                catch
                {
                    throw new Exception($"ClickOn: {element.Text} failed with error: {e.Message}");
                }

            }
        }

        public static bool WaitIfDisplayed(IWebDriver driver, By by, int timeSpecified = default(int))
        {
            int time = 45000;
            if (timeSpecified > 0) time = timeSpecified;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(time));

            bool txtEmptyStatus = false;
            try
            {
                txtEmptyStatus = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed;
            }
            catch { }

            return txtEmptyStatus;
        }

        public static void Type(IWebDriver driver, IWebElement element, string value, double secondsToWait = 20)
        {

            try
            {
                VerifyPageCompleteState(driver, secondsToWait);

                element.Clear();

                element.SendKeys(value);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(element, value));

            }
            catch (Exception e)
            {
                throw new Exception($"Type text for  {element.Text} failed with error: {e.Message}");
            }
        }
    }
}
