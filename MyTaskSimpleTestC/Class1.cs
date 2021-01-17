using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTaskSimpleTestC
{
    [TestFixture]
    public class Class1
    {
            IWebDriver driver;
            [SetUp]
            public void Setup()
            {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver= new ChromeDriver(options);
            driver.Url = "https://rozetka.com.ua/ua/";
            driver.Manage().Window.Maximize();
        }

            [Test]
            public void CheckTitle()
            {
                //Type "Selenium" and check title
                IWebElement web1 = driver.FindElement(By.XPath("//input[@class='search-form__input ng-untouched ng-pristine ng-valid']"));
                web1.SendKeys("Selenium");
                web1.SendKeys(Keys.Enter);
                IWebElement getTitle = driver.FindElement(By.XPath("//h1[@class='catalog-heading']"));
                string title = getTitle.Text;
                Console.WriteLine(title);
                Assert.AreEqual("«Selenium»", title);
            }

            [Test]
            public void CountMenuButtons()
            {
                //Count of buttons in "Menu"
                IReadOnlyCollection<IWebElement> buttonsElements = driver.FindElements(By.XPath("//div[@class='menu-wrapper menu-wrapper_state_static']/ul/li"));
                int count = buttonsElements.Count();
                Assert.AreEqual(17, count);
            }

            [TearDown]
            public void close()
            {
                driver.Close();
                driver.Quit();
            }
        }
    }

