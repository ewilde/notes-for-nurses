namespace Edward.Wilde.Note.For.Nurses.iOS
{
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.Common;

    using global::MonoTouch.Foundation;
    using global::MonoTouch.UIKit;

    using global::System;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        private UIWindow window;

        private TabBarController tabBar;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            this.window = new UIWindow(UIScreen.MainScreen.Bounds);

            this.tabBar = new TabBarController();

            this.window.RootViewController = this.tabBar;

            var majorVersionString = UIDevice.CurrentDevice.SystemVersion.Substring(0, 1);
            var majorVersion = Convert.ToInt16(majorVersionString);
            if (majorVersion >= 5)
            { // gotta love Appearance in iOS5
                UINavigationBar.Appearance.TintColor = Application.ColorNavBarTint;
            }

            // make the window visible
            this.window.MakeKeyAndVisible();

            return true;
        }
    }
}