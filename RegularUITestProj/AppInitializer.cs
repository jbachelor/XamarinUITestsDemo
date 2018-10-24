using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace RegularUITestProj
{
    public class AppInitializer
    {
        public static int testNumber = 0;
        public static IApp app = null;

        public static IApp StartApp(Platform platform)
        {
            int maxAttempts = 5;
            bool appDidLaunch = false;
            testNumber++;

            for (int i = 0; i < maxAttempts; i++)
            {
                Console.WriteLine($"**** {nameof(AppInitializer)}.{nameof(StartApp)}:  Attempt {i + 1} for test {testNumber} ({platform}).");
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
            // If the iOS or Android app being tested is included in the solution 
            // then open the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif

            if (platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    // Update this path to point to your Android app and uncomment the
                    // code if the app is not included in the solution.
                    //.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
                    .StartApp();
            }
            else
            {
                app = ConfigureApp
                .iOS
                // Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                //.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
                .StartApp();
            }

            return app;
        }
    }
}
