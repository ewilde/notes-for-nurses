namespace Edward.Wilde.Note.For.Nurses.iOS.Screens.iPad.Patients
{
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.Common.Patients;
    using Edward.Wilde.Note.For.Nurses.iOS.UI.Controls;

    using MonoTouch.UIKit;

    using global::System;

    /// <summary>
    /// Split view screen used to display the patient search list and the patient detail form
    /// </summary>
    public class PatientsSplitView : IntelligentSplitViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsSplitView" /> class.
        /// </summary>
        public PatientsSplitView()
        {
            this.Delegate = new PatientsSplitViewDelegate();
            this.SearchList = new PatientsListScreen(this);
            this.MasterDetail = new PatientInformationMasterDetail();
            this.ViewControllers = new UIViewController[] {this.SearchList, this.MasterDetail};
        }

        /// <summary>
        /// Gets or sets the search list.
        /// </summary>
        /// <value>The search list.</value>
        public PatientsListScreen SearchList { get; set; }

        /// <summary>
        /// Gets or sets the master detail.
        /// </summary>
        /// <value>The master detail.</value>
        public PatientInformationMasterDetail MasterDetail { get; set; }

        /// <summary>
        /// Shows the patient on the detail form.
        /// </summary>
        /// <param name="patientId">The patient id.</param>
        public void ShowPatient (int patientId)
        {
            this.MasterDetail.Update(patientId);
        }

        /// <inheritdoc />
        [Obsolete("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation", false)]
        public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
        {
            return true;
        }

        /// <summary>
        /// Delegate class used to determine when to hide and show the search controller
        /// </summary>
        public class PatientsSplitViewDelegate : UISplitViewControllerDelegate
        {
            /// <inheritdoc />
            public override bool ShouldHideViewController(UISplitViewController svc, UIViewController viewController, UIInterfaceOrientation inOrientation)
            {
                return inOrientation == UIInterfaceOrientation.Portrait
                    || inOrientation == UIInterfaceOrientation.PortraitUpsideDown;
            }

            /// <summary>
            /// When switching to portrait mode this method is invoked to hide the search view controller.
            /// <para>
            ///     As well as hiding the controller a button is placed on the navigation bar in order to popup the
            ///     search view controller, should the user wish to change the currently selected detail
            /// </para>
            /// </summary>
            public override void WillHideViewController(UISplitViewController svc, UIViewController aViewController, UIBarButtonItem barButtonItem, UIPopoverController pc)
            {
                var masterDetail = svc.ViewControllers[1] as PatientInformationMasterDetail;

                if (masterDetail != null)
                {
                    masterDetail.AddNavBarButton(barButtonItem);
                    masterDetail.Popover = pc;
                }
            }

            /// <summary>
            /// When switch back to landscape mode, show the search view controller and remove the search controllers
            /// associated navigation bar button.
            /// </summary>
            public override void WillShowViewController(UISplitViewController svc, UIViewController aViewController, UIBarButtonItem button)
            {
                var masterDetail = svc.ViewControllers[1] as PatientInformationMasterDetail;

                if (masterDetail != null)
                {
                    masterDetail.RemoveNavBarButton();
                    masterDetail.Popover = null;
                }
            }
        }
    }
}
