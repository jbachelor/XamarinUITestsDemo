using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace RegularUITestProj
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            IApp app = null;
            int maxAttempts = 5;
            bool appDidLaunch = false;

            for (int i = 0; i < maxAttempts; i++)
            {
                Console.WriteLine($"**** {nameof(AppInitializer)}.{nameof(StartApp)}:  Attempt {i + 1}");
                try
                {
                    app = TryToLaunchAppOnPlatform(platform);
                    appDidLaunch = true;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"**** {nameof(AppInitializer)}.{nameof(StartApp)}:  FAILED TO LAUNCH APP WITH EXCEPTION:\n{ex}\n\n\n\n");
                }
            }

            if (appDidLaunch == false)
            {
                Console.WriteLine($"\n\n\n**** App failed to launch even after 5 attempts. Giving up.\n\n\n");
            }

            return app;
        }

        private static IApp TryToLaunchAppOnPlatform(Platform platform)
        {
            IApp app;
            if (platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    // TODO: Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    .StartApp();
            }
            else
            {
                app = ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
                .StartApp();
            }

            return app;
        }
    }
}
