namespace Edward.Wilde.Note.For.Nurses.iOS.Screens.Common.Patients
{
    using Edward.Wilde.Note.For.Nurses.Core.Data;
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.iOS.Screens.iPad.Patients;
    using Edward.Wilde.Note.For.Nurses.iOS.UI.Controls;

    using MonoTouch.Dialog;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    using global::System.Collections.Generic;
    using global::System.Linq;

    /// <summary>
    /// The patient list screen. Supports search for patient and displaying
    /// patients in an A-Z list.
    /// </summary>
    public class PatientsListScreen : UpdateManagerLoadingDialogViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsListScreen" /> class.
        /// This constructor is called by the iPhone.
        /// </summary>
        public PatientsListScreen()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatientsListScreen" /> class.
        /// This constructor is called by the iPad.
        /// </summary>
        /// <param name="splitView">The split view.</param>
        public PatientsListScreen(PatientsSplitView splitView)
        {
            this.SplitView = splitView;
        }

        /// <summary>
        /// Gets or sets the split view. This will be null when running on an iPhone.
        /// </summary>
        /// <value>The split view.</value>
        public PatientsSplitView SplitView { get; set; }

        /// <summary>
        /// Gets the patients.
        /// </summary>
        /// <value>The patients.</value>
        protected IList<Pupil> Pupils { get; private set; }

        /// <inheritdoc />
        protected override void PopulateTable()
        {
            this.Pupils = DataManager.GetPupils().OrderBy(item => item.LastName).ToList();

            this.Root = new RootElement("Pupils")
                       {
                           this.Pupils.GroupBy(patient => patient.Index)
                               .OrderBy(list => list.Key)
                               .Select(
                                   list =>
                                   new Section(list.Key)
                                       {
#pragma warning disable 612,618
                                           list.Select(
                                               eachSpeaker =>
                                               (Element)
                                               new PatientElement(eachSpeaker, this.SplitView))
#pragma warning restore 612,618
                                       })
                       };

            // hide search until pull-down
            TableView.ScrollToRow(NSIndexPath.FromRowSection(0, 0), UITableViewScrollPosition.Top, false);
        }
    }
}
