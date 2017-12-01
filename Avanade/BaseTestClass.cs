using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Text;

namespace Avanade
{
    public class BaseTestClass : IDisposable
{
    internal IWebDriver driver;
    private object verificationErrors;
    static string baseUrl;
    protected string screenshotFolderLocation = null;
    public Parameters externalParameters = null;

    /// <summary>
    /// Importing parameters from parameters.json file.
    /// </summary>
    public void ImportsettingsFromJson()
    {
        if (externalParameters == null)    
        {
            using (var file = File.OpenRead("../../parameters.json"))
            using (StreamReader sr = new StreamReader(file))
            {
                var sPlik = sr.ReadToEnd();
                externalParameters = Newtonsoft.Json.JsonConvert.DeserializeObject<Parameters>(sPlik);
                Convert();
            }
        }
    }
    public void Convert()
    {
        baseUrl = externalParameters.baseUrl;
        screenshotFolderLocation = externalParameters.screenshotFolderLocation;
    }
    public class Parameters
    {
        public string baseUrl;
        public string screenshotFolderLocation;
    }

    /// <summary>
    /// xunit constructor
    /// </summary>
    public BaseTestClass() 
    {
        ImportsettingsFromJson();

        driver = new ChromeDriver();
        verificationErrors = new StringBuilder();
        driver.Navigate().GoToUrl(baseUrl); 
        driver.Manage().Window.Maximize();
    }
    /// <summary>
    /// xunit deconstructor
    /// </summary>
    ~BaseTestClass() 
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.Equal("", verificationErrors.ToString());
    }


    /// <summary>
    /// required for IDisposable
    /// </summary>
    public void Dispose()      
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.Equal("", verificationErrors.ToString());
    }
}
}
