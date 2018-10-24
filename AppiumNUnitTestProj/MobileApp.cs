using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using AppiumNUnitTestProj.Helpers;

namespace AppiumNUnitTestProj
{
    public static class MobileApp
    {
        private static Lazy<AppiumDriver<AppiumWebElement>> _lazyDriver =
            new Lazy<AppiumDriver<AppiumWebElement>>(LoadDriver);

        private static AppiumDriver<AppiumWebElement> _driver;
        public static AppiumDriver<AppiumWebElement> Driver
        {
            get => _driver ?? (_driver = _lazyDriver.Value);
        }

        public static AppiumDriver<AppiumWebElement> LoadDriver()
        {
            // Setup your driver for either iOS or Android
            var capabilities = GetCapabilities();
            switch (UITestConfiguration.Current.Platform)
            {
                case Xamarin.Forms.Device.iOS:
                    return new IOSDriver<AppiumWebElement>(UITestConfiguration.Current.AppiumServer, capabilities, TimeSpan.FromMinutes(3));
                case Xamarin.Forms.Device.Android:
                    return new AndroidDriver<AppiumWebElement>(UITestConfiguration.Current.AppiumServer, capabilities);
                default:
                    return null;
            }
        }

        private static DesiredCapabilities GetCapabilities()
        {
            var capabilities = new DesiredCapabilities();
            foreach (var cap in UITestConfiguration.Current.Capabilities)
            {
                capabilities.SetCapability(cap.Key, cap.Value);
            }
            return capabilities;
        }
    }
}
