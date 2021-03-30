using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class SubmissionReceivedPO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By successfulMessage = By.XPath("//h5[@id='submissionReceivedModallLabel']");
        private readonly By pinCode = By.XPath("//p[text()='PIN code']/following::p");
        private readonly By btnDone = By.XPath("//input[@id='submissionReceivedIdHidden']/../div/div[2]/div[2]/div");

        #endregion

        #region IWebElements 
        private IWebElement _successfulMessage => _webDriver.FindElement(successfulMessage);
        private IWebElement _pinCode => _webDriver.FindElement(pinCode);
        private IWebElement _btnDone => _webDriver.FindElement(btnDone);
        #endregion

        public SubmissionReceivedPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public string GetSuccessfulMessage()
        {
            WaitUntil.WaitElement(_webDriver, successfulMessage);
            string message = _successfulMessage.Text;
            return message;
        }

        public string GetPinCode()
        {
            string pin = _pinCode.Text;
            return pin;
        }

        public RequestsPO PressDoneButton()
        {
            _btnDone.Click();
            WaitUntil.WaitSomeInterval(3);
            return new RequestsPO(_webDriver);
        }
        
    }
}
