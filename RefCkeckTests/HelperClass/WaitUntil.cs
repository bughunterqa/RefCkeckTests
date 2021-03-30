using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using System.Threading.Tasks;

namespace RefCkeckTests.HelperClass
{
    public static class WaitUntil
    {
        public static void ShouldLocate(IWebDriver webDriver, string location)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.UrlContains(location));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find out that app in specific location: {location}", ex);
            }
        }

        public static void WaitSomeInterval(int seconds = 2)
        {
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
        }

        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 10)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
