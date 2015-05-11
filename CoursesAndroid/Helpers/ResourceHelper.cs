using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CoursesAndroid.Helpers
{
    public static class ResourceHelper
    {
        private static Dictionary<string, int> _resourceDictionary; 
        public static int TranslateDrawable(String drawable)
        {
            _resourceDictionary = new Dictionary<string, int>();
            int resource;

            if (_resourceDictionary.ContainsKey(drawable))
            {
                resource = _resourceDictionary[drawable];
            }
            else
            {
                try
                {
                    Type drawableType = typeof(Resource.Drawable);
                    FieldInfo resourceFieldInfo = drawableType.GetField(drawable);

                    resource = (int)resourceFieldInfo.GetValue(null);
                    _resourceDictionary.Add(drawable, resource);
                }
                catch (Exception)
                {
                    return -1;
                }
            }

            
            return resource;
        }
    }
}