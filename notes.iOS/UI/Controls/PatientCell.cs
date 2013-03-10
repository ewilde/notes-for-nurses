using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.iOS.UI.Controls
{
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.iOS.Drawing;

    using MonoTouch.Dialog.Utilities;
    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    using global::System.Drawing;

    public class PatientCell : UITableViewCell, IImageUpdated
    {
        static UIFont bigFont = UIFont.FromName("Helvetica-Light", Fonts.Font16pt);
        static UIFont smallFont = UIFont.FromName("Helvetica-LightOblique", Fonts.Font10pt);
        UILabel nameLabel, companyLabel;
        UIImageView image;

        const int imageSpace = 44;
        const int padding = 8;

        public PatientCell(UITableViewCellStyle style, NSString ident, Patient showSpeaker)
            : base(style, ident)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Blue;

            nameLabel = new UILabel()
            {
                TextAlignment = UITextAlignment.Left,
                Font = bigFont,
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f)
            };
            companyLabel = new UILabel()
            {
                TextAlignment = UITextAlignment.Left,
                Font = smallFont,
                TextColor = UIColor.DarkGray,
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f)
            };

            image = new UIImageView();

            UpdateCell(showSpeaker);

            ContentView.Add(nameLabel);
            ContentView.Add(companyLabel);
            ContentView.Add(image);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var full = ContentView.Bounds;
            var bigFrame = full;

            bigFrame.X = imageSpace + padding + padding + 5;
            bigFrame.Y = 13; // 15 -> 13
            bigFrame.Height = 23;
            bigFrame.Width -= (imageSpace + padding + padding);
            nameLabel.Frame = bigFrame;

            var smallFrame = full;
            smallFrame.X = imageSpace + padding + padding + 5;
            smallFrame.Y = 15 + 23;
            smallFrame.Height = 15; // 12 -> 15
            smallFrame.Width -= (imageSpace + padding + padding);
            companyLabel.Frame = smallFrame;

            image.Frame = new RectangleF(8, 8, 44, 44);
        }

        public void UpdateCell(Patient patient)
        {
            nameLabel.Text = patient.DisplayName;
            companyLabel.Text = patient.DisplaySummary;

            if (!string.IsNullOrWhiteSpace(patient.ImageUrl))
            {
                var u = new Uri(patient.ImageUrl);
                image.Image = ImageLoader.DefaultRequestImage(u, this);
            }
        }

        public void UpdatedImage(Uri uri)
        {
            image.Image = ImageLoader.DefaultRequestImage(uri, this);
        }
    }	
}
