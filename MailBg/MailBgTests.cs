using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MailBg
{
    public class MailBgTests
    {
        private const string baseUrl = "https://mail.bg/idx#mailbox/inbox";
        private WebDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();   
            driver.Manage().Window.Maximize();  

        }

       
        

        [Test]
        public void Test_InputInvalidUser()
        {

            driver.Url = baseUrl;

            Thread.Sleep(3000);

            var emailInput = driver.FindElement(By.Name("user"));
            emailInput.SendKeys("petar@abv.bg");

            var passInput = driver.FindElement(By.Name("pass"));  
            passInput.SendKeys("lalala");

            var loginButton = driver.FindElement(By.LinkText("ВЛЕЗ"));
            loginButton.Click();

            Thread.Sleep(10000);

            var pageSource = driver.PageSource;

            Assert.True(pageSource.Contains("Грешни адрес или парола."));

        }

        //Регистрация на нов имейл адрес

        [Test]
        public void Test_RegisterInvalidUser()
        {

            driver.Url = baseUrl;

            Thread.Sleep(3000);

            var registerUser = driver.FindElement(By.XPath("//a[@class='signup-link'][contains(.,'Регистрация на нов имейл адрес »')]"));
            registerUser.Click();
            
            var inputUser = driver.FindElement(By.Id("signup_user"));
            inputUser.SendKeys("@@$% ^&% **^$$$");

            var passInput = driver.FindElement(By.Name("pass"));
            passInput.SendKeys("lalalala");

            var passInputConf = driver.FindElement(By.Name("confpass"));
            passInputConf.SendKeys("lalalala");

            var emailPhone = driver.FindElement(By.Id("mail_phone_input"));
            emailPhone.SendKeys("#@##$$$$$$");

            var dropDownButton = driver.FindElement(By.XPath("(//span[contains(@class,'input_drop_down')])[1]"));
            dropDownButton.Click();

            var manSelect = driver.FindElement(By.XPath("(//li[@class='drop_down_list_item list_no_icon'][contains(.,'Мъж')])[1]"));
            manSelect.Click();

            var dropDownTwo = driver.FindElement(By.XPath("(//span[contains(@class,'input_drop_down')])[2]"));
            dropDownTwo.Click();

            var twentySecond = driver.FindElement(By.XPath("(//li[@class='drop_down_list_item list_no_icon'][contains(.,'22')])[1]"));
            twentySecond.Click();

            var monthButton = driver.FindElement(By.XPath("(//span[contains(@class,'input_drop_down')])[3]"));
            monthButton.Click();

            var monthSelect = driver.FindElement(By.XPath("(//li[@class='drop_down_list_item list_no_icon'][contains(.,'Януари')])[1]"));
            monthSelect.Click();

            var yearButton = driver.FindElement(By.XPath("(//span[contains(@class,'input_drop_down')])[4]"));
            yearButton.Click();

            var yearSelect = driver.FindElement(By.XPath("(//li[@class='drop_down_list_item list_no_icon'][contains(.,'1983')])[1]"));
            yearSelect.Click();

            var agreeTerms = driver.FindElement(By.XPath("(//span[@class='checkbox'][contains(.,'Съгласен съм с общите условия *')])[1]"));
            agreeTerms.Click();

            Thread.Sleep(1000);

            var agreePolicy = driver.FindElement(By.XPath("(//span[contains(.,'Съгласен съм с Политиката за защита на лични данни и Политика за бисквитките. *')])[1]"));
            Thread.Sleep(1000);
            agreePolicy.Click();

            var saveButton = driver.FindElement(By.XPath("(//a[@class='button small'][contains(.,'ЗАПАЗИ')])[1]"));
            saveButton.Click();

            var pageSource = driver.PageSource;

            Assert.True(pageSource.Contains("Невалиден имейл адрес"));
        }


    }
}