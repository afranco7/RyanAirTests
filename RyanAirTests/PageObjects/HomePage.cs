using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanAirTests.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private string baseUrl;

        public HomePage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
            this.baseUrl = "https://www.ryanair.com/gb/en";
        }

        public void GoToPage()
        {
            SeleniumActions.Actions.GoToPage(driver, baseUrl);
        }

        public IWebElement departureField => driver.FindElement(By.Id("input-button__departure"));

        private readonly By countryOriginBy = By.XPath("//span[@class='countries__country-inner' and text()=' Portugal ']");
        public IWebElement countryOrigin => driver.FindElement(countryOriginBy);
        public IWebElement airportOrigin => driver.FindElement(By.XPath("//span[@data-ref='airport-item__name' and contains(text(),'Lisbon')]"));

        private readonly By countryDestinationBy = By.XPath("//span[@class='countries__country-inner' and text()=' France ']");
        public IWebElement countryDestination => driver.FindElement(countryDestinationBy);

        private readonly By airportDestinationBy = By.XPath("//span[@data-ref='airport-item__name' and contains(text(),' Paris Beauvais ')]");
        public IWebElement airportDestination => driver.FindElement(airportDestinationBy);

        private readonly By decMonthBy = By.XPath("//div[@class='m-toggle__month' and text()=' Dec ']");
        public IWebElement decMonth => driver.FindElement(decMonthBy);

        public IWebElement departureDate => driver.FindElement(By.XPath("//div[@data-id='2020-12-06']"));

        public IWebElement returnDate => driver.FindElement(By.XPath("//div[@data-id='2021-01-02']"));

        public IWebElement adultsPlusIcon => driver.FindElement(By.XPath("//*[@data-ref='passengers-picker__adults']//div[@class='counter__button']"));

        public IWebElement childrenPlusIcon => driver.FindElement(By.XPath("//*[@data-ref='passengers-picker__children']//div[@class='counter__button']"));

        public IWebElement doneButton => driver.FindElement(By.XPath("//button[text()=' Done ']"));

        public IWebElement searchButton => driver.FindElement(By.XPath("//button[@data-ref='flight-search-widget__cta']"));

        public void clickOnDepartureField()
        {
            SeleniumActions.Actions.ClickOn(driver, departureField);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(countryOriginBy));
        }

        public void clickOnAirportOrigin()
        {
            SeleniumActions.Actions.ClickOn(driver, airportOrigin);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(countryDestinationBy));
        }

        public void clickOnCountryDestination()
        {
            SeleniumActions.Actions.ClickOn(driver, countryDestination);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(airportDestinationBy));
        }

        public void clickOnAirportDestination()
        {
            SeleniumActions.Actions.ClickOn(driver, airportDestination);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(decMonthBy));
        }

        public void enterDataAndSearchFlight()
        {

            clickOnDepartureField();
            SeleniumActions.Actions.ClickOn(driver, countryOrigin);
            clickOnAirportOrigin();
            clickOnCountryDestination();
            clickOnAirportDestination();
            SeleniumActions.Actions.ClickOn(driver, decMonth);
            SeleniumActions.Actions.ClickOn(driver, departureDate);
            SeleniumActions.Actions.ClickOn(driver, returnDate);
            SeleniumActions.Actions.ClickOn(driver, adultsPlusIcon);
            SeleniumActions.Actions.ClickOn(driver, childrenPlusIcon);
            SeleniumActions.Actions.ClickOn(driver, doneButton);
            SeleniumActions.Actions.ClickOn(driver, searchButton);

        }
       
    }
}
