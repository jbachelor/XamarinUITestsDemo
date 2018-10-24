using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;

namespace AppiumNUnitTestProj.Pages
{
    public abstract class BasePage
    {
        protected AppiumDriver<AppiumWebElement> Driver => MobileApp.Driver;
    }
}