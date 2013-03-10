using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.iOS.Screens.Common.Patients
{
    using Edward.Wilde.Note.For.Nurses.Core.Data;
    using Edward.Wilde.Note.For.Nurses.Core.Model;
    using Edward.Wilde.Note.For.Nurses.iOS.Drawing;
    using Edward.Wilde.Note.For.Nurses.iOS.UI.Controls;

    using MonoTouch.Dialog.Utilities;
    using MonoTouch.UIKit;

    using global::System.Drawing;

    public class PatientDetailsScreen : UIViewController, IImageUpdated
    {
        UILabel nameLabel, titleLabel, companyLabel;
        UITextView bioTextView;
        UIImageView image;

        int y = 0;
        int speakerId;
        Pupil pupil;
        EmptyOverlay emptyOverlay;

        const int ImageSpace = 80;		

        public PatientDetailsScreen(int id)
        {
            this.View.BackgroundColor = UIColor.White;

            nameLabel = new UILabel()
            {
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.FromName("Helvetica-Light", Fonts.Font16pt),
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f)
            };
            titleLabel = new UILabel()
            {
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.FromName("Helvetica-LightOblique", Fonts.Font10pt),
                TextColor = UIColor.DarkGray,
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f)
            };
            companyLabel = new UILabel()
            {
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.FromName("Helvetica-Light", Fonts.Font10pt),
                TextColor = UIColor.DarkGray,
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f)
            };
            bioTextView = new UITextView()
            {
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.FromName("Helvetica-Light", Fonts.Font10_5pt),
                BackgroundColor = UIColor.FromWhiteAlpha(0f, 0f),
                ScrollEnabled = true,
                Editable = false
            };
            image = new UIImageView();

            this.View.AddSubview(this.nameLabel);
            this.View.AddSubview(this.titleLabel);
            this.View.AddSubview(this.companyLabel);
            this.View.AddSubview(this.bioTextView);
            this.View.AddSubview(this.image);
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();

            if (EmptyOverlay.ShowIfRequired(ref emptyOverlay, this.pupil, this.View, "No pupil information", "Images/Empty/pupil.png")) return;

            var full = this.View.Bounds;
            var bigFrame = full;

            bigFrame.X = ImageSpace + 13 + 17;
            bigFrame.Y = y + 27; // 15 -> 13
            bigFrame.Height = 26;
            bigFrame.Width -= (ImageSpace + 13 + 17);
            nameLabel.Frame = bigFrame;

            var smallFrame = full;
            smallFrame.X = ImageSpace + 13 + 17;
            smallFrame.Y = y + 27 + 26;
            smallFrame.Height = 15; // 12 -> 15
            smallFrame.Width -= (ImageSpace + 13 + 17);
            titleLabel.Frame = smallFrame;

            smallFrame.Y += y + 17;
            companyLabel.Frame = smallFrame;

            image.Frame = new RectangleF(13, y + 15, 80, 80);

            if (!String.IsNullOrEmpty(this.pupil.MedicalHistory))
            {
                if (Application.IsPhone)
                {
                    // for now, hardcode iPhone dimensions to reduce regressions
                    SizeF size = bioTextView.StringSize(this.pupil.MedicalHistory
                                        , bioTextView.Font
                                        , new SizeF(310, 580)
                                        , UILineBreakMode.WordWrap);
                    bioTextView.Frame = new RectangleF(5, y + 115, 310, size.Height);
                }
                else
                {
                    var f = new SizeF(full.Width - 13 * 2, full.Height - (image.Frame.Y + 80 + 20));
                    //					SizeF size = bioTextView.StringSize (pupil.Bio
                    //										, bioTextView.Font
                    //										, f
                    //										, UILineBreakMode.WordWrap);
                    bioTextView.Frame = new RectangleF(5, image.Frame.Y + 80 + 10
                                        , f.Width
                                        , f.Height);
                }
            }
            else
            {
                bioTextView.Frame = new RectangleF(5, y + 115, 310, 30);
            }
        }

        // for masterdetail
        public void Update(int patientId)
        {
            speakerId = patientId;
            this.pupil = DataManager.GetPupil(speakerId);
            Update();
            this.View.LayoutSubviews();
        }

        public void Clear()
        {
            this.pupil = null;
            nameLabel.Text = "";
            titleLabel.Text = "";
            companyLabel.Text = "";
            bioTextView.Text = "";
            image.Image = null;
            this.View.LayoutSubviews(); // show the grey 'no speaker' message
        }

        void Update()
        {
            if (this.pupil == null) { nameLabel.Text = "not found"; return; }

            nameLabel.Text = this.pupil.DisplayName;
            titleLabel.Text = this.pupil.Teacher.DisplayName;
            companyLabel.Text = this.pupil.DisplaySummary;

            if (!String.IsNullOrEmpty(this.pupil.MedicalHistory))
            {
                bioTextView.Text = this.pupil.MedicalHistory;
                bioTextView.Font = UIFont.FromName("Helvetica-Light", Fonts.Font10_5pt);
                bioTextView.TextColor = UIColor.Black;
            }
            else
            {
                bioTextView.Font = UIFont.FromName("Helvetica-LightOblique", Fonts.Font10_5pt);
                bioTextView.TextColor = UIColor.Gray;
                bioTextView.Text = "No background information available.";
            }
            if (!string.IsNullOrWhiteSpace(this.pupil.ImageUrl))
            {
                var u = new Uri(this.pupil.ImageUrl);
                image.Image = ImageLoader.DefaultRequestImage(u, this);
            }
        }

        public void UpdatedImage(Uri uri)
        {
            image.Image = ImageLoader.DefaultRequestImage(uri, this);
        }

        public string Title { get; set; }
    }
}
