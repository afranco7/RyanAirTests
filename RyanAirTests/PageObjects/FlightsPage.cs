using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanAirTests.PageObjects
{
    public class FlightsPage
    {
        private IWebDriver driver;        

        public FlightsPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
        }

        public IWebElement departureLateralScrollArrow => driver.FindElement(By.XPath("//button[@class='carousel-next']"));

        private readonly By dateDec12By = By.XPath("//button[@data-ref='2020-12-12']");
        public IWebElement dateDec12 => driver.FindElement(dateDec12By);

        public IWebElement returnLateralScrollArrow => driver.FindElement(By.XPath("//div[contains(@class,'inbound')]//button[@class='carousel-next']/carousel-arrow[@class='ng-star-inserted']"));
        private readonly By dateJan6By = By.XPath("//button[@data-ref='2021-01-06']");
        public IWebElement dateJan6 => driver.FindElement(dateJan6By);

        private readonly By cardInfoDepartureBy = By.XPath("//*[@data-e2e='flight-card--outbound']");
        public IWebElement cardInfoDeparture => driver.FindElement(cardInfoDepartureBy);

        private readonly By buttonValueFareDepartureBy = By.XPath("//span[text()='Continue with Value fare']");
        public IWebElement buttonValueFareDeparture => driver.FindElement(buttonValueFareDepartureBy);

        private readonly By cardInfoReturnBy = By.XPath("//div[contains(@class,'inbound')]//div[@class='card-info']");
        public IWebElement cardInfoReturn => driver.FindElement(cardInfoReturnBy);

        private readonly By buttonValueFareReturnBy = By.XPath("//span[text()='Continue with Value fare']");
        public IWebElement buttonValueFareReturn => driver.FindElement(buttonValueFareReturnBy);

        private readonly By buttonLoginLaterBy = By.XPath("//span[text()='Log in later']");
        public IWebElement buttonLoginLater => driver.FindElement(buttonLoginLaterBy);

        private readonly By passenger1NameBy = By.XPath("//*[@id='formState.passengers.ADT-0.name']");
        public IWebElement passenger1Name => driver.FindElement(passenger1NameBy);
        private readonly By passenger1TitleBy = By.XPath("//div[@data-ref='pax-details__ADT-0']//button");
        public IWebElement passenger1Title => driver.FindElement(passenger1TitleBy);
        private readonly By passenger1TitleMsBy = By.XPath("//div[text()='Ms']");
        public IWebElement passenger1TitleMs => driver.FindElement(passenger1TitleMsBy);
        private readonly By ppassenger1SurnameBy = By.Id("formState.passengers.ADT-0.surname");
        public IWebElement ppassenger1Surname => driver.FindElement(ppassenger1SurnameBy);


        private readonly By passenger2NameBy = By.XPath("//*[@id='formState.passengers.ADT-1.name']");
        public IWebElement passenger2Name => driver.FindElement(passenger2NameBy);
        private readonly By passenger2TitleBy = By.XPath("//div[@data-ref='pax-details__ADT-1']//button");
        public IWebElement passenger2Title => driver.FindElement(passenger2TitleBy);
        private readonly By passenger2TitleMrBy = By.XPath("//div[text()='Mr']");
        public IWebElement passenger2TitleMr => driver.FindElement(passenger2TitleMrBy);
        private readonly By ppassenger2SurnameBy = By.Id("formState.passengers.ADT-1.surname");
        public IWebElement ppassenger2Surname => driver.FindElement(ppassenger2SurnameBy);


        private readonly By passenger3NameBy = By.XPath("//*[@id='formState.passengers.CHD-0.name']");
        public IWebElement passenger3Name => driver.FindElement(passenger3NameBy);
        
        private readonly By ppassenger3SurnameBy = By.Id("formState.passengers.CHD-0.surname");
        public IWebElement ppassenger3Surname => driver.FindElement(ppassenger3SurnameBy);

        private readonly By continueButtonBy = By.XPath("//button[text()=' Continue ']");
        public IWebElement continueButton => driver.FindElement(continueButtonBy);

        public void clickOnDepartureLateralScrollArrow()
        {
            SeleniumActions.Actions.ClickOn(driver, departureLateralScrollArrow);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(dateDec12By));
        }

        public void clickOnReturnLateralScrollArrow()
        {
            SeleniumActions.Actions.ClickOn(driver, returnLateralScrollArrow);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(dateJan6By));
        }

        public void changeTheDepartureAndReturnDates()
        {
            SeleniumActions.Actions.WaitIfDisplayed(driver, cardInfoDepartureBy);
            clickOnDepartureLateralScrollArrow();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dateDec12));
            SeleniumActions.Actions.ClickOn(driver, dateDec12);
            clickOnReturnLateralScrollArrow();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dateJan6));
            SeleniumActions.Actions.ClickOn(driver, dateJan6);
        }

        public void selectTarifaValueForDeparture()
        {
            SeleniumActions.Actions.ClickOn(driver, cardInfoDeparture);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(buttonValueFareDepartureBy));
            SeleniumActions.Actions.ClickOn(driver, buttonValueFareDeparture);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(cardInfoReturn));
        }

        public void selectTarifaValueForReturn()
        {
           
            SeleniumActions.Actions.ClickOn(driver, cardInfoReturn);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(buttonValueFareDepartureBy));
            SeleniumActions.Actions.ClickOn(driver, buttonValueFareReturn);
            SeleniumActions.Actions.WaitIfDisplayed(driver, buttonLoginLaterBy);
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(buttonLoginLater));
        }

        public void clickOnButtonLoginLater()
        {
            SeleniumActions.Actions.ClickOn(driver, buttonLoginLater);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='formState.passengers.ADT-0.name']")));
        }

        public void fillPassengersDetails()
        {
            SeleniumActions.Actions.Type(driver, passenger1Name, "Sónia ");
            SeleniumActions.Actions.ClickOn(driver, passenger1Title);

            SeleniumActions.Actions.ClickOn(driver, passenger1TitleMs);
            SeleniumActions.Actions.Type(driver, ppassenger1Surname, "Pereira");


            SeleniumActions.Actions.Type(driver, passenger2Name, "Diogo  ");
            SeleniumActions.Actions.ClickOn(driver, passenger2Title);

            SeleniumActions.Actions.ClickOn(driver, passenger2TitleMr);
            SeleniumActions.Actions.Type(driver, ppassenger2Surname, "Bettencourt");

            SeleniumActions.Actions.Type(driver, passenger3Name, "Inês ");            
            SeleniumActions.Actions.Type(driver, ppassenger3Surname, "Marçal");
        }

        public void clickOnContinueButton()
        {
            SeleniumActions.Actions.ClickOn(driver, continueButton);
            SeleniumActions.Actions.VerifyPageCompleteState(driver);
        }
    }
}
