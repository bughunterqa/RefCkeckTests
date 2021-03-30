using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests.HelperClass
{
    class Navigation
    {
        #region XPath
        private readonly By requestsPage = By.XPath("//a[@class='sidebar-link ']/span[text()='Requests']/parent::*");
        private readonly By logOut = By.XPath("//span[text()='Logout']/..");
        #endregion


        #region IWebElements 
        private IWebElement _requestsPage => _webDriver.FindElement(requestsPage);
        private IWebElement _logOut => _webDriver.FindElement(logOut);
        #endregion


        #region Constructor
        private IWebDriver _webDriver;

        public Navigation(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        #endregion



        public RequestsPO GoToRequestPage()
        {
            WaitUntil.WaitSomeInterval();
            _requestsPage.Click();
            return new RequestsPO(_webDriver);
        }

        public SignInPO LogOut()
        {
            WaitUntil.WaitElement(_webDriver, logOut);
            _logOut.Click();
            return new SignInPO(_webDriver);
        }
    }
}
