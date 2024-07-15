using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;
using Nest;
using Actions = OpenQA.Selenium.Interactions.Actions;
using System.Xml.Linq;
using SeleniumTest;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SeleniumTest
{
    public class Methods
    {
        private WebDriver driver;

        public Methods(WebDriver driver) {
            this.driver = driver;
        }

        public WebDriver returnDriver()
        {
            return driver;
        }
        public void Dropdown() {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Navigate().GoToUrl(Paths.dropdownlink);
            //select-demo
            string dayOfTheWeek = "Wednesday";
            driver.FindElement(By.Id(Paths.dropdown)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id(Paths.dropdown)).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath(Paths.dropdown_xpath)).Click();
            Thread.Sleep(3000);

        }
        public void CSSPractice()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Navigate().GoToUrl(Paths.css_link);
            Expand();
            //select-demo
            driver.FindElement(By.CssSelector(Paths.css_id)).Click();
            Thread.Sleep(3000);
            Back();
            driver.FindElement(By.CssSelector(Paths.css_id_a)).Click();
            Thread.Sleep(3000);
            Back();
            driver.FindElement(By.CssSelector(Paths.css_class)).Click();
            Thread.Sleep(3000);
            Back();

        }


        public void Expand()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Manage().Window.Maximize();

        }
        /*
         I was having the same issue and solved it by installing some missing NuGet Packages:

          Nunit.ConsoleRunner
          Nunit3TestAdapter
          Microsoft.Net.Test.sdk*/
        public void ListOflinks()
        {
            WebElement footer = (WebElement)driver.FindElement(By.Id("ups-footer"));
            var numberOfLinks = footer.FindElements(By.TagName("a")).Count;
            List<string> listOfPaths = new List<string>(3);
            {
                listOfPaths.Add("https://www.ups.com/track?loc=en_US&requester=ST/");
                listOfPaths.Add("https://www.ups.com/ship/guided/origin?tx=91135515992826063&loc=en_US");
                listOfPaths.Add("https://www.ups.com/us/en/support/contact-us.page");
                listOfPaths.Add("https://www.ups.com/marketingpreferences?loc=en_US#/emailsubscription");
                listOfPaths.Add("https://about.ups.com/us/en/home.html");
                listOfPaths.Add("https://www.ups.com/us/en/supplychain/Home.page");
                listOfPaths.Add("https://www.theupsstore.com/?loc=en_US");
                listOfPaths.Add("https://global.jobs-ups.com/location");
                listOfPaths.Add("https://www.facebook.com/ups");
                listOfPaths.Add("https://twitter.com/UPS");
                listOfPaths.Add("https://www.instagram.com/ups/");
                listOfPaths.Add("https://www.linkedin.com/authwall?trk=bf&trkInfo=AQGLSNCzBoMwtgAAAYbnCoYAxDWKxqASW5Ok4WZngoy-nUv57K8q5_HJYjHTMRiXsmslkri0NiJVyux-FiNZQkZGcRowj_sNxwKtKi4fJwWNQmK1l_tGY7ZmL-8GiyDI2sYoqCw=&original_referer=&sessionRedirect=https%3A%2F%2Fwww.linkedin.com%2Fcompany%2Fups");
                listOfPaths.Add("https://www.youtube.com/c/UPS");
                listOfPaths.Add("https://www.ups.com/us/en/global.page");
                listOfPaths.Add("https://www.ups.com/us/en/support/shipping-support/legal-terms-conditions/fight-fraud.page");
                listOfPaths.Add("https://www.ups.com/us/en/support/shipping-support/legal-terms-conditions.page");
                listOfPaths.Add("https://www.ups.com/us/en/support/shipping-support/legal-terms-conditions/website-terms-of-use.page");
                listOfPaths.Add("https://www.ups.com/us/en/support/shipping-support/legal-terms-conditions/california-privacy-rights.page");
                listOfPaths.Add("https://www.ups.com/us/en/support/shipping-support/legal-terms-conditions/privacy-notice.page");
                listOfPaths.Add("https://www.ups.com/us/en/Home.page");
                listOfPaths.Add("https://www.ups.com/ppwa/doWork?loc=en_US");

            }
        }
        public void Platform(){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Manage().Window.Maximize();
            // Get the current window’s handle
            var handle = driver.CurrentWindowHandle;
            driver.SwitchTo().NewWindow(WindowType.Tab);
            var handles = driver.WindowHandles;

           
            driver.Navigate().GoToUrl(Paths.LambdaSitePath);
            IWebElement platformButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.PartialLinkText(Paths.platformPath)));
            platformButton.Click();
            Thread.Sleep(8000);
            IWebElement platformText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Paths.checkPlatformPage)));
            string textInPlathormPage = platformText.Text;
            try
            {
                Console.WriteLine("check now Platform text");
                Assert.AreEqual(Paths.checkPlatformText, textInPlathormPage);
            }
            catch (WebException ex) { }
            //Switch to the window you want active in your test
            driver.SwitchTo().Window(handle);

            driver.SwitchTo().Window(handles[0]);
            Thread.Sleep(3000);
            IWebElement enterprizeButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Paths.enterprizePath)));
            enterprizeButton.Click();
            Thread.Sleep(3000);
            IWebElement dropdownButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Paths.dropdownElement)));
            dropdownButton.Click();
            Thread.Sleep(3000);
            IWebElement enterprizeText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Paths.checkEnterprize)));
            string textInEnterprizePage = enterprizeText.Text;
            try
            {
                Console.WriteLine("check now Enterprize text");
                Assert.AreEqual(Paths.checkEnterprizeText, textInEnterprizePage);
            }
            catch (WebException ex) { }
            Back();
            
        }
        public void Back() { 
        driver.Navigate().Back();
        }
        public void Alert() {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Manage().Window.Maximize();
            // Get the current window’s handle
            var handle = driver.CurrentWindowHandle;
            
            driver.Navigate().GoToUrl(Paths.alertPath);
            driver.FindElement(By.XPath(Paths.alerTbutton)).Click();
            // Dismiss the alert
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Dismiss();
            driver.FindElement(By.XPath(Paths.alerTbutton)).Click();
            // Accept the alert
            Thread.Sleep(3000);
            driver.SwitchTo().Alert().Accept();
        }
        public void Title()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            driver.Manage().Window.Maximize();
            
            driver.Navigate().GoToUrl(Paths.titleHandling);
            string Title = "Pure CSS toggle buttons";
            string readingTitle = driver.Title.ToString();
            // Validate that the page title is correct
            Assert.That(Title == readingTitle);
        }
        public void CountFooterLinks()
        {
            WebElement footer = (WebElement)driver.FindElement(By.Id("ups-footer"));
            var numberOfLinks = footer.FindElements(By.TagName("a")).Count;
            var links = footer.FindElements(By.TagName("a"));
            Console.WriteLine("number of links is" + numberOfLinks);
        }

        public void GoToFootercheckLinks()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Actions actions = new Actions(driver);
            var element = driver.FindElement(By.XPath(Paths.footer));
            actions.MoveToElement(element);
            driver.FindElement(By.XPath(Paths.span)).Click();
            driver.FindElement(By.XPath(Paths.trackLink)).Click();
            try
            {
                Console.WriteLine("Track will check now");
                Thread.Sleep(3000);
                bool trackIsDisplayed = driver.FindElement(By.XPath("//*[@id='navbarSupportedContent']/div/ul[2]/li/a[2]")).Displayed;
                if (!trackIsDisplayed)
                {
                    Console.WriteLine("Track is not displayed");
                    Assert.AreEqual("True", trackIsDisplayed);
                }
                else
                {
                    Console.WriteLine("Track is displayed");

                }
            }
            catch (WebException ex) { }
            Thread.Sleep(2000);
            driver.Navigate().Back();
            driver.Navigate().Back();
            Thread.Sleep(3000);
            actions.MoveToElement(element);

            driver.FindElement(By.XPath(Paths.shippingLink)).Click();
            try
            {
                Console.WriteLine("Shiping will check now");
                Thread.Sleep(3000);
                bool shipmentIsDisplayed = driver.FindElement(By.XPath("//*[@id=\"ups-main\"]/div[12]/app/ng-component/div/div/div/div/ng-component/section/h2")).Displayed;
                if (!shipmentIsDisplayed)
                {
                    Console.WriteLine("Shiping is not displayed");
                    Assert.AreEqual("True", shipmentIsDisplayed);
                }
                else
                {
                    Console.WriteLine("shiping is displayed");

                }
            }
            catch (WebException ex) { }
            driver.Navigate().Back();
        }
        public void CheckLogo() { 
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        try {
           Console.WriteLine("Logo will check now");
           bool logoIsDisplayed = driver.FindElement(By.XPath(Paths.logoPath)).Displayed;
           if (!logoIsDisplayed) {
           Console.WriteLine("Logo is not displayed");
           Assert.AreEqual("True", logoIsDisplayed);
                                 }
            else {
            Console.WriteLine("Logo is displayed");
        
                  }
            }
        catch (WebException ex) { }
            
        }
    }
}
