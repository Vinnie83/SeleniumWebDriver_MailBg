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

            Assert.Pass();
        }
    }
}