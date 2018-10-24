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
            Steps.ThenIShouldSeeTheElement("mainPage");
        }

        [Test]
        public void AppLaunchesAndShowsWelcomeLabel()
        {
            Steps.ThenIShouldSeeTheElement("WelcomeLabel");
        }

        [Test]
        public void AppLaunchesAndShowsAlertButton()
        {
            Steps.ThenIShouldSeeTheElement("AlertButton");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithTitle()
        {
            Steps.AndIWaitForTheElement("AlertButton");
            Steps.AndITapTheElement("AlertButton");
            Steps.ThenIShouldSeeTheElement("Alert!");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithMessage()
        {
            Steps.AndIWaitForTheElement("AlertButton");
            Steps.AndITapTheElement("AlertButton");
            Steps.ThenIShouldSeeTheElement("You've tapped the show alert button.");
        }

        [Test]
        public void TappingShowAlertShowsAlertWithButton()
        {
            Steps.AndIWaitForTheElement("AlertButton");
            Steps.AndITapTheElement("AlertButton");
            Steps.ThenIShouldSeeTheElement("ok");
        }
    }
}
