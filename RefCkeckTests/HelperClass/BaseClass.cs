using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RefCkeckTests.HelperClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace RefCkeckTests
{
    class BaseClass
    {
        protected IWebDriver _webDriver;

        protected SignInPO signInPage;
        protected HomePO homePage;
        protected RequestsPO requestsPage;
        protected Navigation navigation;
        protected CreateRequestPO createRequestPage;
        protected SubmissionReceivedPO submissionReceivedPage;
        protected SignInWithPinPO signInWithPinPage;
        protected RequestDetailsByPinPO requestDetailsByPinPage;


        private void InitPageObjects()
        {
            signInPage = new SignInPO(_webDriver);
            homePage = new HomePO(_webDriver);
            requestsPage = new RequestsPO(_webDriver);
            navigation = new Navigation(_webDriver);
            createRequestPage = new CreateRequestPO(_webDriver);
            submissionReceivedPage = new SubmissionReceivedPO(_webDriver);
            signInWithPinPage = new SignInWithPinPO(_webDriver);
            requestDetailsByPinPage = new RequestDetailsByPinPO(_webDriver);
        }


        [SetUp]
        protected void SetUp()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(VeriablesForTests.URL);

            //create instances of classes 
            InitPageObjects();
        }



        [TearDown]
        protected void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
