using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace RegularUITestProj
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Steps.GivenIHaveLaunchedLuxor(platform);
        }

        [TearDown]
        public void AfterEachTest()
        {

        }

        [Test]
        public void AppLaunchesAndShowsMainPage()
        {
            AppInitializer.app.WaitForElement("mainPage");
        }

        [Test]
        public void AppLaunchesAndShowsWelcomeLabel()
        {
            AppInitializer.app.WaitForElement("WelcomeLabel");
        }

        [Test]
        public void AppLaunchesAndShowsAlertButton()
        {
            AppInitializer.app.WaitForElement("AlertButton");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithTitle()
        {
            AppInitializer.app.WaitForElement("AlertButton");
            AppInitializer.app.Tap("AlertButton");
            AppInitializer.app.WaitForElement("Alert!");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithMessage()
        {
            AppInitializer.app.WaitForElement("AlertButton");
            AppInitializer.app.Tap("AlertButton");
            AppInitializer.app.WaitForElement("You've tapped the show alert button.");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithButton()
        {
            AppInitializer.app.WaitForElement("AlertButton");
            AppInitializer.app.Tap("AlertButton");
            AppInitializer.app.WaitForElement("ok");
        }
    }
}
