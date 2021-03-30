using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class RequestsPO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By btnNewRequest = By.CssSelector("div.topnavbar-search-button button.main-button");
        private readonly By btnNewSellerRequest = By.Id("newSellerRequestButton");
        private readonly By inputEmail = By.Id("newRequestsEmail");
        private readonly By btnSubmitEnteredEmail = By.Id("submitEnteredEmailButton");
        #endregion


        #region IWebElements 
        private IWebElement _btnNewRequest => _webDriver.FindElement(btnNewRequest);
        private IWebElement _btnNewSellerRequest => _webDriver.FindElement(btnNewSellerRequest);
        private IWebElement _inputEmail => _webDriver.FindElement(inputEmail);
        private IWebElement _btnSubmitEnteredEmail => _webDriver.FindElement(btnSubmitEnteredEmail);
        #endregion




        public RequestsPO(IWebDriver webDrever)
        {
            _webDriver = webDrever;
        }


        public RequestsPO PressNewRequestButton()
        {
            WaitUntil.WaitElement(_webDriver, btnNewRequest);
            WaitUntil.WaitSomeInterval(1);
            _btnNewRequest.Click();
            return this;
        }

        public RequestsPO PressNewSellerRequestButton()
        {
            WaitUntil.WaitElement(_webDriver, btnNewSellerRequest);
            _btnNewSellerRequest.Click();
            return this;
        }

        public CreateRequestPO TypeEmailBuyer(string email)
        {
            WaitUntil.WaitElement(_webDriver, inputEmail);
            _inputEmail.SendKeys(email);
            _btnSubmitEnteredEmail.Click();
            return new CreateRequestPO(_webDriver);
        }
    }
}
