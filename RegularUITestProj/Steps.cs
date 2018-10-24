using System;
using Xamarin.UITest;

namespace RegularUITestProj
{
    public static class Steps
    {
        public static void GivenIHaveLaunchedLuxor(Platform platform)
        {
            AppInitializer.StartApp(platform);
        }

        public static void ThenIShouldSeeTheElement(string elementName)
        {
            AndIWaitForTheElement(elementName);
        }

        public static void AndIWaitForTheElement(string elementName)
        {
            AppInitializer.app.WaitForElement(elementName);
        }

        public static void AndITapTheElement(string elementName)
        {
            AppInitializer.app.Tap(elementName);
        }
    }
}
