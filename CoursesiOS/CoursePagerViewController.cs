using System;
using System.Drawing;
using CoursesLibrary;
using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace CoursesiOS
{
    [Register("CoursePagerViewController")]
    public class CoursePagerViewController : UIViewController
    {
        private UIPageViewController pageViewController;
        private CourseManager _courseManager;
        public CoursePagerViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            // Perform any additional setup after loading the view
            pageViewController = new UIPageViewController(
                UIPageViewControllerTransitionStyle.Scroll,
                UIPageViewControllerNavigationOrientation.Horizontal);

            pageViewController.View.Frame = View.Bounds;
            View.AddSubviews(pageViewController.View);

            _courseManager = new CourseManager();
            _courseManager.MoveFirst();

            CourseViewController firstCourseViewController = CreateCourseViewController();

            pageViewController.SetViewControllers(new UIViewController[]
            {
                firstCourseViewController
            },UIPageViewControllerNavigationDirection.Forward, false, null);

            pageViewController.GetNextViewController = GetNextViewController;
            pageViewController.GetPreviousViewController = GetPreviousViewController;
        }

        private CourseViewController CreateCourseViewController()
        {
            CourseViewController courseViewController = new CourseViewController();
            courseViewController.Course = _courseManager.Current;
            courseViewController.CoursePosition = _courseManager.CurrentPosition;
            return courseViewController;
        }

        public UIViewController GetNextViewController(
            UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;
            var referenceCourseViewController = referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) return null;

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (_courseManager.CanMoveNext)
            {
                _courseManager.MoveNext();
                returnCourseViewController = CreateCourseViewController();
            }

            return returnCourseViewController;
        }
        public UIViewController GetPreviousViewController(
            UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;
            var referenceCourseViewController = referenceViewController as CourseViewController;
            if (referenceCourseViewController == null) return null;

            _courseManager.MoveTo(referenceCourseViewController.CoursePosition);
            if (_courseManager.CanMovePrev)
            {
                _courseManager.MovePrev();
                returnCourseViewController = CreateCourseViewController();
            }

            return returnCourseViewController;
        }
    }
}