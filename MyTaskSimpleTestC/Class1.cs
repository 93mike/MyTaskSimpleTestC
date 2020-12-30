using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTaskSimpleTestC
{
    [TestFixture]
    public class Class1
    {
            IWebDriver driver;
            [SetUp]
            public void Setup()
            {
                driver = new ChromeDriver("C:\\Education");
                driver.Url = "https://www.seleniumeasy.com/";
                driver.Manage().Window.Maximize();
            }

            [Test]
            public void Test1()
            {
                //Type "Selenium" and check title
                IWebElement web1 = driver.FindElement(By.XPath("//div[@class='input-group']/input"));
                web1.SendKeys("Selenium");
                web1.SendKeys(Keys.Enter);
                IWebElement getTitle = driver.FindElement(By.XPath("//*[@id='site-name']//h1"));
                string title = getTitle.Text;
                Console.WriteLine(title);
                Assert.AreEqual("Selenium Easy", title);
                driver.Navigate().Back();
            }

            [Test]
            public void Test2()
            {
                //Open "Maven" in new window and navigate to new window
                IWebElement maven = driver.FindElement(By.XPath("//li[@class='leaf']/a[@href='/maven-tutorials']"));
                Actions action = new Actions(driver);
                action.KeyDown(Keys.Control).MoveToElement(maven).Click().KeyUp(Keys.Control).Perform();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                IWebElement getTitleMaven = driver.FindElement(By.XPath("//div[@class='section-title']/h1"));
                string titleMaven = getTitleMaven.Text;
                Assert.AreEqual("Maven Tutorials", titleMaven);
            }

            [Test]
            public void Test3()
            {
                //Count of buttons in (Jenkins configuration with Maven and GitHub)
                IWebElement maven = driver.FindElement(By.XPath("//li[@class='leaf']/a[@href='/maven-tutorials']"));
                maven.Click();
                IReadOnlyCollection<IWebElement> buttonsElements = driver.FindElements(By.XPath("//article[@id='node-232']//ul[@class='links list-inline']/li"));
                int count = buttonsElements.Count();
                Assert.AreEqual(3, count);
            }

            [TearDown]
            public void close()
            {
                driver.Close();
                driver.Quit();
            }
        }
    }

