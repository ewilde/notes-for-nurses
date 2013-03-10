namespace Edward.Wilde.Note.For.Nurses.iOS.Screens
{
    using MonoTouch.Dialog;
    using MonoTouch.UIKit;

    public class UpdateManagerLoadingDialogViewController : DialogViewController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateManagerLoadingDialogViewController" /> class.
        /// </summary>
        public UpdateManagerLoadingDialogViewController() : base(UITableViewStyle.Plain, null, true)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the table will be reloaded on ViewWillAppear.
        /// </summary>
        protected bool AlwaysRefresh { get; set; }

        /// <inheritdoc />
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //TODO use events to fire Update manager etc..

            this.PopulateTable();
        }

        /// <summary>
        /// Your implementation should get data from the UpdateManager 
        /// and set the Root for the DialogViewController
        /// </summary>
        protected virtual void PopulateTable()
        {
        }
    }
}