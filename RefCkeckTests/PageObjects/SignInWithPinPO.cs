using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class SignInWithPinPO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By inputEmail = By.Id("pin-email");
        private readonly By inputPassword = By.Id("pin-input");
        private readonly By btnContinue = By.XPath("//button[@type='submit']");
        #endregion

        #region IWebElements 
        private IWebElement _inputEmail => _webDriver.FindElement(inputEmail);
        private IWebElement _inputPassword => _webDriver.FindElement(inputPassword);
        private IWebElement _btnContinue => _webDriver.FindElement(btnContinue);

        #endregion

        public SignInWithPinPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public RequestDetailsByPinPO LogInWithPin(string email, string pin)
        {
            WaitUntil.WaitElement(_webDriver, inputEmail);
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(pin);
            _btnContinue.Click();
            return new RequestDetailsByPinPO(_webDriver);
        }
    }
}
