using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Avanade.Methods
{
    public class NavigateMainPage
    {
        /// <summary>
        /// scrooling page to Join Section
        /// </summary>
        /// <param name="driver"></param>
        public static void ScroolToJoin (IWebDriver driver)
        {
            var element = driver.FindElement(By.CssSelector("#careers"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

        }

        /// <summary>
        /// finds and returns button ExploreCareers
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static IWebElement ExploreCareers_Find (IWebDriver driver)
        {
            IWebElement element = driver.FindElement(By.CssSelector("a[id*='cta_button'"));
            return element;
        }
    }
}