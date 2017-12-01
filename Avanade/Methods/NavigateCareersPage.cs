using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace Avanade.Methods
{
    public class NavigateCareersPage
    {
        /// <summary>
        /// finds and returns ExploreAvanadeCareers button
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public static IWebElement ExploreAvanadeCareers_Find(IWebDriver driver)
        {
            var selector = By.CssSelector("a[id*='cta_button'");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(selector));  //waiting for button because some times it appears after a moment

            IWebElement element = driver.FindElement(selector);
            return element;
        }
    }
}
