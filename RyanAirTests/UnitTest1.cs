using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RyanAirTests.PageObjects;

namespace RyanAirTests
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void TestMethod1()
        {
            HomePage homePage = new HomePage(driver);
            FlightsPage flightsPage = new FlightsPage(driver);
            homePage.GoToPage();
            homePage.enterDataAndSearchFlight();

            flightsPage.changeTheDepartureAndReturnDates();
            flightsPage.selectTarifaValueForDeparture();
            flightsPage.selectTarifaValueForReturn();
            flightsPage.clickOnButtonLoginLater();
            flightsPage.fillPassengersDetails();
            flightsPage.clickOnContinueButton();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
