using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.iOS.UI.Controls
{
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.Common.Patients;
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.iPad.Patients;

    using MonoTouch.Dialog;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    /// <summary>
    /// Speaker element.
    /// on iPhone, pushes via MT.D
    /// on iPad, sends view to SplitViewController
    /// </summary>
    public class PatientElement : Element
    {
        private static readonly NSString CellId = new NSString("PatientElement");

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientElement" /> class.
        /// </summary>
        /// <param name="patient">The patient to display.</param>
        public PatientElement(Patient patient) : base(patient.DisplayName)
        {
            this.Patient = patient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientElement" /> class.
        /// </summary>
        /// <param name="patient">The patient to display.</param>
        /// <param name="splitView">The split view controller to be used.</param>
        public PatientElement(Patient patient, PatientsSplitView splitView) : base(patient.DisplayName)
        {
            this.Patient = patient;
            this.PatientsSplitView = splitView;
        }

        /// <summary>
        /// Gets the patients split view controller.
        /// </summary>
        /// <value>The patients split view.</value>
        public PatientsSplitView PatientsSplitView { get; private set; }

        /// <summary>
        /// Gets or sets the patient to display.
        /// </summary>
        /// <value>The patient.</value>
        public Patient Patient { get; set; }

        
        /// <inheritdoc />
        public override UITableViewCell GetCell(UITableView tv)
        {
            var cell = tv.DequeueReusableCell(CellId);
            
            if (cell == null)
            {
                cell = new PatientCell(UITableViewCellStyle.Subtitle, CellId, this.Patient);
            }
            else
            {
                ((PatientCell)cell).UpdateCell(this.Patient);
            }

            return cell;
        }

        /// <summary>
        /// Matches the specified text, searching against the patient,
        /// using display name or display summary.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the supplied text matches part of the patients display name or summary;otherwise <c>false</c>.</returns>
        public override bool Matches(string text)
        {
            return (this.Patient.DisplayName + " " + this.Patient.DisplaySummary).ToLower().IndexOf(text.ToLower()) >= 0;
        }

        /// <summary>
        /// Behaves differently depending on iPhone or iPad
        /// </summary>
        public override void Selected(DialogViewController dvc, UITableView tableView, MonoTouch.Foundation.NSIndexPath path)
        {
            if (this.PatientsSplitView != null)
                this.PatientsSplitView.ShowPatient(Patient.Id);
            else
            {
                var detailsScreen = new PatientDetailsScreen(Patient.Id) { Title = "Patient" };
                dvc.ActivateController(detailsScreen);
            }
        }
    }
}
