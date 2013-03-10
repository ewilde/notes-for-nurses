using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.iOS.Screens.iPad.Patients
{
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.Common.Patients;

    using MonoTouch.UIKit;

    using global::System.Drawing;

    /// <summary>
    /// Class used to display an indiviual patient details screen
    /// </summary>
    public class PatientInformationMasterDetail : UIViewController
    {
        private int colWidth1 = 335;

        protected UINavigationBar NavBar { get; private set; }

        protected PatientDetailsScreen DetailsScreen { get; private set; }

        protected int PatientId { get; set; }

        public UIPopoverController Popover { get; set; }

        public PatientInformationMasterDetail()
        {
            this.NavBar = new UINavigationBar(new RectangleF(0, 0, 768, 44));
            this.NavBar.SetItems(new UINavigationItem[] { new UINavigationItem("Patient Information") }, false);

            this.View.BackgroundColor = UIColor.LightGray;
            this.View.Frame = new RectangleF(0, 0, 768, 768);

            this.DetailsScreen = new PatientDetailsScreen(-1);
            this.DetailsScreen.View.Frame = new RectangleF(0, 44, colWidth1, 728);
            this.DetailsScreen.View.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            this.View.AddSubview(this.DetailsScreen.View);
            this.View.AddSubview(this.NavBar);
        }

        public void AddNavBarButton(UIBarButtonItem barButtonItem)
        {
            barButtonItem.Title = "Patients";
            this.NavBar.TopItem.SetLeftBarButtonItem(barButtonItem, false);
        }

        public void RemoveNavBarButton()
        {
            this.NavBar.TopItem.SetLeftBarButtonItem(null, false);
        }

        public void Update(int patientId)
        {
            this.PatientId = patientId;
            this.DetailsScreen.Update(this.PatientId);
            this.DetailsScreen.View.SetNeedsDisplay();

            if (this.Popover != null)
            {
                this.Popover.Dismiss(true);
            }
        }
    }
}
