// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabBarController.cs" company="Edward Wilde">
//   ©2013 all rights reserved.
// </copyright>
// <summary>
//   Defines the TabBarController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Edward.Wilde.Note.For.Nurses.iOS.Screens.Common
{
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.iPad.Patients;

    using MonoTouch.UIKit;

    using global::System;

    /// <summary>
    /// Tab bar controller. Main application navigation control mechanism. 
    /// Displays a tab bar at the bottom of the screen.
    /// <para>
    /// Currently has the following tabs:
    /// * Patient tab
    /// </para>
    /// </summary>
    public class TabBarController : UITabBarController
    {
        /// <summary>
        /// Gets or sets the patient screen.
        /// </summary>
        /// <value>
        /// The patient screen.
        /// </value>
        public UIViewController PatientScreen { get; set; }

        /// <inheritdoc />
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.AddPatientScreen();
         
            if (Application.IsPhone)
            {
                throw new NotImplementedException("Register view controllers for iphone");
            }
            else
            {
                this.ViewControllers = new UIViewController[] { this.PatientScreen };
            }

            this.CustomizableViewControllers = new UIViewController[]{};
            this.SelectedViewController = this.PatientScreen;
        }

        /// <summary>
        /// Only allow iPad application to rotate, iPhone is always portrait
        /// </summary>
        [Obsolete("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation", false)]
        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            if (Application.IsTablet)
            {
                return true;
            }
            
            return toInterfaceOrientation == UIInterfaceOrientation.Portrait;
        }

        /// <summary>
        /// Adds the patient screen.
        /// </summary>
        private void AddPatientScreen()
        {
            if (Application.IsPhone)
            {
                throw new NotImplementedException("Add navigation controller and screen for iphone");
            }
            else
            {
                this.PatientScreen = new PatientsSplitView();
                this.PatientScreen.TabBarItem = new UITabBarItem("Pupils", UIImage.FromBundle("Images/Tabs/patients.png"), 1);
            }
        }
    }
}
