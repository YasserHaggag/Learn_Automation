using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Learn_Automation;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;


namespace Learn_Selenium
{
    [TestFixture]

    public class UnitTest2
    {

        // initialize ExtentReports and attach the HtmlReporter
        //public static ExtentReports extent;
        //public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentTest test;

       [OneTimeSetUp]
        public static void Report()
        {
            extent = new ExtentReports();
            //extent = new ExtentReports();
            // initialize the HtmlReporter
            //var htmlReporter = new ExtentHtmlReporter("E:\\Selenium needs\\extent.html");
            var htmlReporter = new ExtentHtmlReporter("E:\\Selenium needs\\extent.html");
            htmlReporter.Configuration().DocumentTitle = "newTest";
            htmlReporter.Configuration().Theme = Theme.Dark;
            //extent.AttachReporter(htmlReporter);
            extent.AttachReporter(htmlReporter);

            //Add System Info
            //extent.AddSystemInfo("OS", "Windows");
            //extent.AddSystemInfo("Browser", "Chrome");




        }
        Help x = new Help();
        


        string a = "Ahmed";
       static IWebDriver chrome;

        //Take a Screen Shot Method
        public static void Sshot(string filename)
        {
            Screenshot x = ((ITakesScreenshot)chrome).GetScreenshot();
            x.SaveAsFile(@"E:\\Selenium needs\\" + filename, ScreenshotImageFormat.Jpeg);
        }

        [SetUp]
        public void Intialize()
        {
            //Help.Report("First", "Descccccc");
            chrome = new ChromeDriver(@"E:\Selenium needs");
            chrome.Url = "https://www.google.com.eg/";
        }

        [Test, Order(1)]
        public void SearchFor_Echo()
        {

            for (int i=1;i<4;i++)
               
            {

                chrome.FindElement(By.Id("lst-ib")).SendKeys(x.ExcelSetup(i, 1));
                chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
                chrome.FindElement(By.Id("lst-ib")).Clear();

            }
            
            //Screenshot ss = ((ITakesScreenshot)chrome).GetScreenshot();
            //ss.SaveAsFile(@"E:\Selenium needs\Searchfor.Jpeg", ScreenshotImageFormat.Jpeg);
            //ITakesScreenshot shot = chrome as ITakesScreenshot;
            //Screenshot ss = shot.GetScreenshot();
            //ss.SaveAsFile("Searchfor_1000 for echo", ScreenshotImageFormat.Jpeg);
                

        }
        [Test, Order(4)]
        public void Lookfor_Ahmed()
        {
            test = extent.CreateTest("Ahmed Case");
            //test= extent.CreateTest("AhmedTest");
           
            chrome.FindElement(By.Id("lst-ib")).SendKeys("Ahmed");
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            Screenshot x = ((ITakesScreenshot)chrome).GetScreenshot();
            x.SaveAsFile(@"E:\\Selenium needs\\Ahmed.Jpeg" , ScreenshotImageFormat.Jpeg);
            Assert.IsFalse(true);
          
            
        }
        [Test, Order(3)]
        public void search_Khalid()
        {
           test = extent.CreateTest("search_Khalid");

            chrome.FindElement(By.Id("lst-ib")).SendKeys("Khalid");

            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);

            Sshot("Khalid.Jpeg");
        }
        [Test, Order(2)]
        public void Searchfor_1000()
        {
            test=extent.CreateTest("Searchfor_1000");

            chrome.FindElement(By.Id("lst-ib")).SendKeys("1000");
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            Sshot("1000.Jpeg");
        }

        //[Test, Order(2)]
        //public void Wazzuf_Case()
        //{
        //    chrome.Url = "https://wuzzuf.net/login";
        //    chrome.FindElement(By.LinkText("https://wuzzuf.net/signup/joinow")).Click();
        //    chrome.FindElement(By.)
        //}

        [TearDown]
        public void End()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
           // var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errormessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errormessage);
            }
            else { test.Log(Status.Pass, status + errormessage); }
            //if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            //{
            //  //  test.Log(Status.Fail, status + errormessage);
            //}
            //else { //test.Log(Status.Pass, status + errormessage); }
            
          extent.Flush();
            chrome.Close();
        }
    }
}

