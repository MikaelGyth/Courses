using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CoursesAndroid.Helpers;
using CoursesLibrary;

namespace CoursesAndroid
{
    //[Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        Button _buttonPrev;
        Button _buttonNext;
        TextView _textTitle;
        ImageView _imageCourse;
        TextView _textDescription;
        private CourseManager _courseManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _buttonPrev = FindViewById<Button>(Resource.Id.buttonPrev);
            _buttonNext = FindViewById<Button>(Resource.Id.buttonNext);
            _textTitle = FindViewById<TextView>(Resource.Id.textTitle);
            _imageCourse = FindViewById<ImageView>(Resource.Id.imageCourse);
            _textDescription = FindViewById<TextView>(Resource.Id.textDescription);

            _buttonPrev.Click += buttonPrev_Click;
            _buttonNext.Click += buttonNext_Click;

            _courseManager = new CourseManager();
            _courseManager.MoveFirst();
            UpdateUI();
        }

        void buttonPrev_Click(object sender, EventArgs e)
        {
            _courseManager.MovePrev();
            UpdateUI();
        }

        

        void buttonNext_Click(object sender, EventArgs e)
        {
            _courseManager.MoveNext();
            UpdateUI();
        }

        private void UpdateUI()
        {
            _textTitle.Text = _courseManager.Current.Title;
            _textDescription.Text = _courseManager.Current.Description;
            _imageCourse.SetImageResource(ResourceHelper.TranslateDrawable(_courseManager.Current.Image));
            _buttonNext.Enabled = _courseManager.CanMoveNext;
            _buttonPrev.Enabled = _courseManager.CanMovePrev;
        }
    }
}

