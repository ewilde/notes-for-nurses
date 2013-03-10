// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="Edward Wilde">
//   ©2013 all rights reserved.
// </copyright>
// <summary>s
//   The main application class, the entry point to the application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Edward.Wilde.Note.For.Nurses.iOS
{
    using MonoTouch.UIKit;

    /// <summary>
    /// The main application class, the entry point to the application.
    /// </summary>
    public class Application
    {
        public static readonly UIColor ColorNavBarTint = UIColor.FromRGB(55, 87, 118);
        public static readonly UIColor ColorTextHome = UIColor.FromRGB(192, 205, 223);
        public static readonly UIColor ColorHeadingHome = UIColor.FromRGB(150, 210, 254);
        public static readonly UIColor ColorCellBackgroundHome = UIColor.FromRGB(36, 54, 72);
        public static readonly UIColor ColorTextLink = UIColor.FromRGB(9, 9, 238);		

        /// <summary>
        /// Gets a value indicating whether the current device is a phone.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the current device is a phone; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPhone
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current device is a tablet.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this device is a tablet; otherwise, <c>false</c>.
        /// </value>
        public static bool IsTablet
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this devuce has a retina display.
        /// </summary>
        /// <value>
        /// <c>true</c> if this device has retina; otherwise, <c>false</c>.
        /// </value>
        public static bool HasRetina
        {
            get
            {
                if (MonoTouch.UIKit.UIScreen.MainScreen.RespondsToSelector(new MonoTouch.ObjCRuntime.Selector("scale")))
                {
                    return (MonoTouch.UIKit.UIScreen.MainScreen.Scale == 2.0);
                }
                
                return false;
            }
        }

        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}