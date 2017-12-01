using Xunit;
using OpenQA.Selenium;
using System.Linq;
using Avanade.Methods;

namespace Avanade.Runnable_Tests
{
    public class ExploreCareers : BaseTestClass
    {

        /// <summary>
        /// "There is a total of 5 results for Location: “Poland” and Search by Keyword: ”QA” "
        /// </summary>
        [Fact]
        public void ExploreCareers_CheckingResultsForPolandQA ()
        {
            NavigateMainPage.ScroolToJoin(driver);
            NavigateMainPage.ExploreCareers_Find(driver).Click();
            NavigateCareersPage.ExploreAvanadeCareers_Find(driver).Click();

            NavigateAvanadeCareersPage.SearchByKeyword_Find(driver).Click();
            NavigateAvanadeCareersPage.SearchByKeyword_Find(driver).SendKeys("QA");
            NavigateAvanadeCareersPage.HandleTheFilteringThatDoesNotAcceptKeyboardInput(driver, "Poland");
            NavigateAvanadeCareersPage.SearchJobButton_Find(driver).Click();

            NavigateCareersSearchJobsPage.WaitUntilResultsLoad(driver);

            int locatorElementSize = driver.FindElements(By.CssSelector(".job-listing.ng-scope")).Count();
            Assert.Equal(5, locatorElementSize);
        }

        /// <summary>
        /// "There is at least 1 result for Location “Japan” "
        /// </summary>
        [Fact]
        public void ExploreCareers_CheckingResultsForJapan()
        {
            NavigateMainPage.ScroolToJoin(driver);
            NavigateMainPage.ExploreCareers_Find(driver).Click();
            NavigateCareersPage.ExploreAvanadeCareers_Find(driver).Click();

            //NavigateAvanadeCareersPage.HandleTheFilteringThatDoesNotAcceptKeyboardInput(driver, "Japan");
            //NavigateAvanadeCareersPage.SearchJobButton_Find(driver).Click();

            // Apology I give up on this one.
            driver.Navigate().GoToUrl("https://careers.avanade.com/experienced/jobs?keywords=&page=1&country=%E6%97%A5%E6%9C%AC&lang=ja-JP");
            NavigateCareersSearchJobsPage.WaitUntilResultsLoad(driver);

            int locatorElementSize = driver.FindElements(By.CssSelector(".job-listing.ng-scope")).Count();
            Assert.True(locatorElementSize!=0);
        }

        /// <summary>
        /// 3. One of the qualifications for job offer: Location: “United States”/ “Business Analyst”(Austin, Texas) is:
        /// “Bachelor’s Degree in Business or IT.”
        /// </summary>
        [Fact]
        public void ExploreCareers_CheckingResultsFor_BA_AustinTexas()
        {
            NavigateMainPage.ScroolToJoin(driver);
            NavigateMainPage.ExploreCareers_Find(driver).Click();
            NavigateCareersPage.ExploreAvanadeCareers_Find(driver).Click();

            NavigateAvanadeCareersPage.SearchByKeyword_Find(driver).Click();
            NavigateAvanadeCareersPage.SearchByKeyword_Find(driver).SendKeys("Austin");
            NavigateAvanadeCareersPage.SearchJobButton_Find(driver).Click();

            NavigateCareersSearchJobsPage.WaitUntilResultsLoad(driver);

            IWebElement businessAnalyst = driver.FindElement(By.XPath("//*[text()[contains(.,'Business Analyst')]]"));
            businessAnalyst.Click();

            IWebElement JobDescription = driver.FindElement(By.XPath("//*[text()[contains(.,'Job Description')]]"));

            int locatorElementSize = driver.FindElements(By.XPath("//*[text()[contains(.,'Bachelor’s Degree in Business or IT.')]]")).Count();
            Assert.True(locatorElementSize != 0);
        }
    }
}
