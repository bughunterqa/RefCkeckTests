using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class RequestDetailsByPinPO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By requestDetailsByPin = By.XPath("//div[@class='topnavbar-title']/h1");
        #endregion

        #region IWebElements 
        private IWebElement _requestDetailsByPin => _webDriver.FindElement(requestDetailsByPin);
        #endregion

        public RequestDetailsByPinPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetHeaderRequestDetailsByPin()
        {
            WaitUntil.WaitElement(_webDriver, requestDetailsByPin);
            string headerPin = _requestDetailsByPin.Text;
            return headerPin;
        }
    }
}
