using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Avanade.Methods
{
    /// <summary>
    /// https://www.infusion.com/careers
    /// </summary>
    public class NavigateAvanadeCareersPage
    {
        public static IWebElement SearchByKeyword_Find(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#searchboxfilter"));
            return element;
        }

        public static IWebElement BrowseCountry_Find(IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("div #countries"));
            return element;
        }

        public static void BrowseCountry_Click (IWebDriver driver)
        {
            var element = driver.FindElement(By.CssSelector("div #countries"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
            
        }




        /// <summary>
        /// finds and selects inputString on the country dropdown list
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="inputSearch"></param>
        /// <returns></returns>
        public static void BrowseCountry_FindAndClickCountryOnList (IWebDriver driver, string inputString)
        {
            var element = driver.FindElement(By.XPath("//*[contains(text(), '" + inputString + "')]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Click().Perform();
        }


        public static IWebElement SearchJobButton_Find (IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("#jobsearchclick"));
            return element;
        }

        /// <summary>
        /// This was the hard part for me. As Country is not accepting searching and accepting by keyboard. But I learned JavaScriptExecutor :)
        /// </summary>
        public static void HandleTheFilteringThatDoesNotAcceptKeyboardInput(IWebDriver driver, string country)
        {
            Actions actions = new Actions(driver);

            actions.MoveToElement(driver.FindElement(By.CssSelector("div #countries"))).Click().Perform();

            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().ParentFrame();

            //// Create instance of Javascript executor
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            string title = (string)js.ExecuteScript("return document.title");
            ////Identify the WebElement which will appear after scrolling down
            IWebElement element = driver.FindElement(By.XPath("//*[contains(text(), '"+country+"')]"));
            IWebElement element2 = driver.FindElement(By.CssSelector("#search-jobs"));
            //// execute query which will scroll until that element is not appeared on page.
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element2);

            BrowseCountry_FindAndClickCountryOnList(driver, country);
        }
    }
}
