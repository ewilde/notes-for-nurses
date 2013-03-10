using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edward.Wilde.Note.For.Nurses.iOS.UI.Controls
{
    using Edward.Wilde.Note.For.Nurses.iOS.Drawing;

    using MonoTouch.UIKit;

    using global::System.Drawing;

    public class EmptyOverlay : UIView
    {
        UILabel emptyLabel;
        UIImageView emptyImageView;

        public EmptyOverlay(RectangleF frame, string caption, string emptyImageFileName)
            : base(frame)
        {
            // configurable bits
            BackgroundColor = UIColor.LightGray;
            AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

            var img = UIImage.FromFile(emptyImageFileName);

            float labelHeight = 22;
            float labelWidth = Frame.Width - 20;

            // derive the center x and y
            float centerX = Frame.Width / 2;
            float centerY = Frame.Height / 2;

            emptyImageView = new UIImageView(new RectangleF(
                centerX - (img.Size.Width / 2),
                centerY - img.Size.Height - 25,
                img.Size.Width,
                img.Size.Height
            ));
            emptyImageView.Image = img;
            emptyImageView.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;


            // create and configure the "Loading Data" label
            emptyLabel = new UILabel(new RectangleF(
                centerX - (labelWidth / 2),
                centerY + 25,
                labelWidth,
                labelHeight
                ));
            emptyLabel.BackgroundColor = UIColor.Clear;
            emptyLabel.TextColor = UIColor.FromRGB(136, 136, 136); //UIColor.White;
            emptyLabel.Font = UIFont.FromName("Helvetica-Light", Fonts.Font16pt);
            emptyLabel.Text = caption;
            emptyLabel.TextAlignment = UITextAlignment.Center;
            emptyLabel.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;

            AddSubview(emptyImageView);
            AddSubview(emptyLabel);
        }
        /// <summary>
        /// Static helper to show the 'empty overlay' if a business object is null
        /// </summary>
        /// <returns>
        /// True if it was required, false if not (ie. the business object is NOT NULL)
        /// </returns>
        public static bool ShowIfRequired(ref EmptyOverlay emptyOverlay
                        , object toShow
                        , UIView view
                        , string caption, string emptyImageFileName)
        {
            if (toShow == null)
            {
                if (emptyOverlay == null)
                {
                    emptyOverlay = new EmptyOverlay(view.Bounds, caption, emptyImageFileName);
                    view.AddSubview(emptyOverlay);
                }
                return true;
            }
            else
            {
                if (emptyOverlay != null)
                {
                    emptyOverlay.RemoveFromSuperview();
                    emptyOverlay = null;
                }
            }
            return false;
        }
    }
}
