using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RyanAirTests.PageObjects
{
    public class FamilySeatingPage
    {
        private IWebDriver driver;

        public FamilySeatingPage(IWebDriver currentDriver)
        {
            this.driver = currentDriver;
        }

        private readonly By familySeatingModalButtonBy = By.XPath("//button[text()=' Okay, got it. ']");
        public IWebElement familySeatingModalButton => driver.FindElement(familySeatingModalButtonBy);

        public IEnumerable<IWebElement> seatsAvailable => driver.FindElements(By.XPath("//div[@data-ref='seat-map__seat-row-33']//button"));

        private readonly By continueButtonBy = By.XPath("//button[@data-ref='seats-action__button-next']");
        public IWebElement continueButton => driver.FindElement(continueButtonBy);
    }
}
