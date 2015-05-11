using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using CoursesAndroid.Helpers;
using CoursesLibrary;

namespace CoursesAndroid
{
    public class CourseFragment : Fragment
    {
        TextView _textTitle;
        ImageView _imageCourse;
        TextView _textDescription;

        public Course Course { get; set; }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.CourseFragment, container, false);
            _textTitle = rootView.FindViewById<TextView>(Resource.Id.textTitle);
            _imageCourse = rootView.FindViewById<ImageView>(Resource.Id.imageCourse);
            _textDescription = rootView.FindViewById<TextView>(Resource.Id.textDescription);

            _textTitle.Text = Course.Title;
            _textDescription.Text = Course.Description;
            _imageCourse.SetImageResource(ResourceHelper.TranslateDrawable(Course.Image));

            return rootView;
        }
    }
}