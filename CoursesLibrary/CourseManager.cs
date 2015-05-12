﻿namespace CoursesLibrary
{
    public class CourseManager
    {
        private Course[] _courses;
        private int _currentIndex;
        private readonly int _lastIndex;

        public CourseManager()
        {
            _courses = InitCourses();
            _lastIndex = _courses.Length - 1;
        }

        private Course[] InitCourses()
        {
            var initCourses = new[]
            {
                new Course
                {
                    Title = "Android for .NET Developers",
                    Description = "Provides an overview of the tools used in the Android " +
                                  "development process including the newly released Android Studio.",
                    Image = "ps_top_card_01"
                },
                new Course
                {
                    Title = "Android Dreams, Widgets, Notifications",
                    Description = "Provide users with a rich and interactive experience " +
                                  "without ever requiring them to open your app.",
                    Image = "ps_top_card_02"
                },
                new Course
                {
                    Title = "Android Photo/Video Programming",
                    Description = "Learn how to capitalize on the Android camera " +
                                  "within your apps to capture still photos and video.",
                    Image = "ps_top_card_03"
                },
                new Course
                {
                    Title = "Android Location-Based Apps",
                    Description = "Cover the wide range of Android location capabilities " +
                                  "including determining user location, power management, and " +
                                  "translating location data to human-readable addresses.",
                    Image = "ps_top_card_04"
                }
            };
            return initCourses;
        }

        public void MoveFirst()
        {
            _currentIndex = 0;
        }

        public void MovePrev()
        {
            if (CanMovePrev)
                --_currentIndex;
        }

        public void MoveNext()
        {
            if (CanMoveNext)
                ++_currentIndex;
        }

        public int Lenght
        {
            get { return _courses.Length; }
        }

        public void MoveTo(int position)
        {
            if(position <= _lastIndex && position >= 0)
                _currentIndex = position;
            else
                throw new System.IndexOutOfRangeException(System.String.Format("{0} is an invalid position. Must be between 1 and {1}",
                position, _lastIndex));
        }

        public Course Current
        {
            get { return _courses[_currentIndex]; }
        }

        public int CurrentPosition
        {
            get { return _currentIndex;}
        }

        public bool CanMovePrev
        {
            get { return _currentIndex > 0; }
        }
        public bool CanMoveNext
        {
            get { return _currentIndex < _lastIndex; }
        }
    }
}