using OpenQA.Selenium;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class CreateRequestPO
    {
        private IWebDriver _webDriver;


        #region XPath
        private readonly By inputSubmitRequestItemName = By.Id("submitRequestItemName");
        private readonly By inputSubmitRequestDescr = By.XPath("//label[@id='submitRequest-descr']/textarea");

        private readonly By dropDownSubmitRequestType = By.Id("submitRequestType");
        private readonly By dropDownSubmitRequestTypeElement = By.XPath("//span[text()='Precious']");

        private readonly By dropDownSubmitRequestWeight = By.Id("submitRequestWeight");
        private readonly By dropDownSubmitRequestUnit = By.Id("submitRequestUnit");
        private readonly By dropDownSubmitRequestUnitElement = By.XPath("//span[text()='Kg']");

        private readonly By dropDownSubmitRequestLevel = By.Id("submitRequestLevel");
        private readonly By dropDownSubmitRequestLevelElement = By.XPath("//span[text()='Authentication']");

        private readonly By btnSubmit = By.Id("submitNewRequestButton");
        private readonly By inputImage = By.Id("new-request-photo");

        #endregion

        #region IWebElements 
        private IWebElement _inputSubmitRequestItemName => _webDriver.FindElement(inputSubmitRequestItemName);
        private IWebElement _inputSubmitRequestDescr => _webDriver.FindElement(inputSubmitRequestDescr);

        private IWebElement _dropDownSubmitRequestType => _webDriver.FindElement(dropDownSubmitRequestType);
        private IWebElement _dropDownSubmitRequestTypeElement => _webDriver.FindElement(dropDownSubmitRequestTypeElement);
        private IWebElement _dropDownSubmitRequestWeight => _webDriver.FindElement(dropDownSubmitRequestWeight);


        private IWebElement _dropDownSubmitRequestUnit => _webDriver.FindElement(dropDownSubmitRequestUnit);
        private IWebElement _dropDownSubmitRequestUnitElement => _webDriver.FindElement(dropDownSubmitRequestUnitElement);

        private IWebElement _dropDownSubmitRequestLevel => _webDriver.FindElement(dropDownSubmitRequestLevel);
        private IWebElement _dropDownSubmitRequestLevelElement => _webDriver.FindElement(dropDownSubmitRequestLevelElement);

        private IWebElement _btnSubmit => _webDriver.FindElement(btnSubmit);
        private IWebElement _inputImage => _webDriver.FindElement(inputImage);

        #endregion

        Random random = new Random();

        public CreateRequestPO(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public CreateRequestPO TypeItemName()
        {
            WaitUntil.WaitElement(_webDriver, inputSubmitRequestItemName);
            int randomNumber = random.Next(1, 99999);
            _inputSubmitRequestItemName.SendKeys("RequestQA " + randomNumber);
            return this;
        }

        public CreateRequestPO TypeDescription()
        {
            _inputSubmitRequestDescr.SendKeys("RequestDescription");
            return this;
        }

        public CreateRequestPO SelectTypeRequest()
        {
            _dropDownSubmitRequestType.Click();
            WaitUntil.WaitElement(_webDriver, dropDownSubmitRequestTypeElement);
            _dropDownSubmitRequestTypeElement.Click();
            return this;
        }

        public CreateRequestPO TypeWeightRequest()
        {
            _dropDownSubmitRequestWeight.SendKeys("13");
            return this;
        }

        public CreateRequestPO SelectUnitRequest()
        {
            _dropDownSubmitRequestUnit.Click();
            WaitUntil.WaitElement(_webDriver, dropDownSubmitRequestUnitElement);
            _dropDownSubmitRequestUnitElement.Click();
            return this;
        }

        public CreateRequestPO SelectServiceLevelRequest()
        {
            _dropDownSubmitRequestLevel.Click();
            WaitUntil.WaitElement(_webDriver, dropDownSubmitRequestLevelElement);
            _dropDownSubmitRequestLevelElement.Click();
            return this;
        }

        public CreateRequestPO UploadImage(string puth)
        {
            _inputImage.SendKeys(puth);
            WaitUntil.WaitSomeInterval(2);
            return this;
        }

        public SubmissionReceivedPO PressSubmitButton()
        {
            _btnSubmit.Click();
            return new SubmissionReceivedPO(_webDriver);
        }
    }
}
