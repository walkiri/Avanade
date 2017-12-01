using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

namespace Avanade.Methods
{
    /// <summary>
    /// https://careers.avanade.com/experienced/jobs
    /// </summary>
    class NavigateCareersSearchJobsPage
    {
        public static void WaitUntilResultsLoad (IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("span[ng-show=\"!isInitialLoad\"]")));
        }
    }
}
