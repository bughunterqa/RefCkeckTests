using NUnit.Framework;
using RefCkeckTests.HelperClass;

namespace RefCkeckTests
{
    [TestFixture]
    class GeneralTests : BaseClass
    {
        
        [Test]
        public void CreateSellerRequest()
        {
            signInPage.LogIn(
                VeriablesForTests.SellerEmail, 
                VeriablesForTests.SellerPassword);

            string ActualWelcomeMessage = homePage.GetWelcomeMessage();
         
            Assert.AreEqual(
                VeriablesForTests.UserNameSellerQA, ActualWelcomeMessage,
                "UserName isn't displayed correct");

            navigation
                .GoToRequestPage()
                .PressNewRequestButton()
                .PressNewSellerRequestButton()
                .TypeEmailBuyer(VeriablesForTests.BuyerEmail)
                .TypeItemName()
                .TypeDescription()
                .SelectTypeRequest()
                .TypeWeightRequest()
                .SelectUnitRequest()
                .SelectServiceLevelRequest()
                .UploadImage(VeriablesForTests.ImageRequest)
                .PressSubmitButton();

            string ActualSuccessfulMessage = submissionReceivedPage.GetSuccessfulMessage();
            Assert.AreEqual("Submission Received!", ActualSuccessfulMessage,
                "Request not created");

            string pinCode = submissionReceivedPage.GetPinCode();

            submissionReceivedPage
                .PressDoneButton();

            navigation
                .LogOut()
                .PressEnterPinCodeButton()
                .LogInWithPin(VeriablesForTests.BuyerEmail, pinCode);

            string ActualHeaderRequestDetailsByPin = requestDetailsByPinPage.GetHeaderRequestDetailsByPin();
            string ExpectedHeaderRequestDetailsByPin = "Request details for " + pinCode;

            Assert.AreEqual(ExpectedHeaderRequestDetailsByPin, ActualHeaderRequestDetailsByPin);





           // WaitUntil.WaitSomeInterval(100000);



        }

    }
}