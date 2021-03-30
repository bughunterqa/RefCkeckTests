using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class SignInPO
    {
        private IWebDriver _webDriver;

        #region XPath
        private readonly By inputEmail = By.Id("signInEmail");
        private readonly By inputPassword = By.Id("signInPassword");
        private readonly By btnSubmit = By.XPath("//button[@type='submit']");
        private readonly By btnEnterPinCode = By.XPath("//a[text()='enter pin code']");
        #endregion

        #region IWebElements 
        private IWebElement _inputEmail => _webDriver.FindElement(inputEmail);
        private IWebElement _inputPassword => _webDriver.FindElement(inputPassword);
        private IWebElement _btnSubmit => _webDriver.FindElement(btnSubmit);
        private IWebElement _btnEnterPinCode => _webDriver.FindElement(btnEnterPinCode);
        #endregion

        public SignInPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public HomePO LogIn(string email, string psw)
        {
            _inputEmail.SendKeys(email);
            _inputPassword.SendKeys(psw);
            _btnSubmit.Click();
            return new HomePO(_webDriver);
        }

        public SignInWithPinPO PressEnterPinCodeButton()
        {
            WaitUntil.WaitElement(_webDriver, btnEnterPinCode);
            _btnEnterPinCode.Click();
            return new SignInWithPinPO(_webDriver);
        }
    }
}
