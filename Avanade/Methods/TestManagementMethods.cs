using System;
using System.Text;
using OpenQA.Selenium;

namespace Avanade.Methods 
{
    class TestManagementMethods : BaseTestClass
    {
        /// <summary>
        /// Taking screenshot usually after test fail.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="fileName"></param>
        public static void TakeScreenshot(IWebDriver driver, string fileName)
        {
            //String folderLocation = screenshotFolderLocation;
            String folderLocation = "C:\\ScreenshotsSelenium\\";

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            try
            {
                filename.Append(fileName);
                filename.Append(DateTime.Now.ToString("_dd-MM-yyyy_HH-mm-ss"));
                filename.Append(".png");
                screenshot.SaveAsFile(filename.ToString(), ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        /// <summary>
        /// Ugly sleep just to slow down the test to see how it's running
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="miliseconds"></param>
        public static void SleepToSeeInMiliseconds(IWebDriver driver, int miliseconds)
        {
            System.Threading.Thread.Sleep(miliseconds);
        }
        
    }
}
