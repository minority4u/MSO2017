﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MSO.StimmApp.Droid.Resources;
using MSO.StimmApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace MSO.StimmApp.Droid.Resources
{
    public class ToastService : IToastService
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}