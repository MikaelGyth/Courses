using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CoursesiOS
{
	public partial class CourseViewController : UIViewController
	{
		public CourseViewController () : base ("CourseViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
            buttonPrev.TouchUpInside += buttonPrev_TouchUpInside;
            buttonNext.TouchUpInside += buttonNext_TouchUpInside;

        }

        void buttonPrev_TouchUpInside(object sender, EventArgs e)
        {
            labelTitle.Text = "Prev Clicked";
            textDescription.Text = "This is the description that displays when Prev is clicked";
            imageCourse.Image = UIImage.FromBundle("ps_top_card_01");
        }
        void buttonNext_TouchUpInside(object sender, EventArgs e)
        {
            labelTitle.Text = "Next Clicked";
            textDescription.Text = "This is the description that displays when Next is clicked";
            imageCourse.Image = UIImage.FromBundle("ps_top_card_02");
        }

    }
}

