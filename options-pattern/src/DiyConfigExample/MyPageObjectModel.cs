using DiyConfigExample.Config;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace DiyConfigExample
{
    public class MyPageObjectModel
    {
        private readonly IWebDriver _driver;
        private readonly MyPageConfig _config = new MyPageConfig();

        public MyPageObjectModel(IWebDriver driver)
        {
            _driver = driver;

            var configRoot = StaticConfigRoot.Instance;
            configRoot.GetSection("urls").Bind(_config);

            //..
        }

        public void NavigateTo() => _driver.Navigate().GoToUrl(_config.MyPageUrl);
    }
}
