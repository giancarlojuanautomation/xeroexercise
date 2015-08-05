using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace XeroExercise.Utils
{
    public class GetWebDriver
    {
        public GetWebDriver()
        {

        }
        
        public IWebDriver _driver { get; set; }

        public IWebDriver returnWebDriver()
        {          
            var browser = ConfigurationManager.AppSettings["Browser"].ToLower();
            switch (browser)
                {
                    case "chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver();
                        break;
                    case "iexplorer":
                    _driver = new InternetExplorerDriver();
                    break;
                default:
                        _driver = new FirefoxDriver();
                        break;
                }
       
            return _driver;  
        }

    }
    
}
