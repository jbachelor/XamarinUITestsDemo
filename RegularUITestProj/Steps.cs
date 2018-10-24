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
    }
}
