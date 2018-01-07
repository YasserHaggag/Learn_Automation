using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Learn_Automation;

namespace Learn_Selenium
{
    [TestFixture]

    public class UnitTest2
    {


        Help x = new Help();
        


        string a = "Ahmed";
        IWebDriver chrome;

        [SetUp]
        public void Intialize()
        {

            chrome = new ChromeDriver(@"E:\Selenium needs");
            chrome.Url = "https://www.google.com.eg/";
        }

        [Test, Order(1)]
        public void SearchFor_Echo()
        {

            for (int i = 0; i < 5; i++)
            {
                chrome.FindElement(By.Id("lst-ib")).SendKeys(x.ExcelSetup(i, 1));
                chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
            }

           
            
        }
        [Test, Order(4)]
        public void Lookfor_Ahmed()
        {

            chrome.FindElement(By.Id("lst-ib")).SendKeys(a);
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }
        [Test, Order(3)]
        public void search_Khalid()
        {

            ;
            chrome.FindElement(By.Id("lst-ib")).SendKeys(x.ExcelSetup(2, 1));
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }
        [Test, Order(2)]
        public void Searchfor_1000()
        {


            chrome.FindElement(By.Id("lst-ib")).SendKeys(x.ExcelSetup(3, 1));
            chrome.FindElement(By.Id("lst-ib")).SendKeys(Keys.Enter);
        }

        [TearDown]
        public void End()
        {
            chrome.Close();
        }
    }
}

