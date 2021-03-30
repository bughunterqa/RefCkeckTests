using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class HomePO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By welcomeMessage = By.CssSelector("div.topnavbar-title h1");
        #endregion

        #region IWebElements 
        private IWebElement _welcomeMessage => _webDriver.FindElement(welcomeMessage);
        #endregion



        public HomePO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }



        public string GetWelcomeMessage()
        {
            WaitUntil.WaitElement(_webDriver, welcomeMessage);
            string message = _welcomeMessage.Text;
            string messageCut = message.Substring(9);
            return messageCut;
        }
    }
}
