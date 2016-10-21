using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using MyTrains.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Droids
{
    [Activity(
        MainLauncher = true,
        Label = "@string/ApplicationName",
        Theme = "@style/Theme.Splash", NoHistory = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
        public class NewSplashScreen : MvxCachingFragmentCompatActivity<SplashViewModel>
        {
            LinearLayout mLinearLayout;
            LinearLayout mFooterLayout;
            ImageButton im;
            LinearLayout includedLayout;
            ISharedPreferencesEditor editor;
            ISharedPreferences prefs;

            public new SplashViewModel ViewModel
            {
                get { return (SplashViewModel)base.ViewModel; }
                set { base.ViewModel = value; }
            }


            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.SplashView);

                mLinearLayout = FindViewById<LinearLayout>(Resource.Id.loginlay);
                mLinearLayout.Visibility = ViewStates.Gone;

                mFooterLayout = FindViewById<LinearLayout>(Resource.Id.footer_layout);
                mFooterLayout.Visibility = ViewStates.Gone;

                includedLayout = FindViewById<LinearLayout>(Resource.Id.internet_retry);
                includedLayout.Visibility = ViewStates.Gone;
                im = FindViewById<ImageButton>(Resource.Id.move_button);
                var something = DoSomeTaskAsync();

                prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                editor = prefs.Edit();
                editor.Clear();
                editor.Commit();
            
            }

            private async Task DoSomeTaskAsync()
            {
               await Task.Delay(1000);
              // PerformAnimation();
               PerformTask();


            }

            private void PerformTask()
            {

               base.ViewModel.NavigateToMainView.Execute();
             
            }

            private void PerformAnimation()
            {
                Animation animation = new TranslateAnimation(0, 0, 0, -550);

                animation.FillAfter = true;
                animation.Duration = 1000;
                animation.AnimationEnd += Animation_AnimationEnd;
                im.StartAnimation(animation);


            }

            private void Animation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
            {
                // includedLayout.Visibility = ViewStates.Visible;
                mLinearLayout.Visibility = ViewStates.Visible;
                mFooterLayout.Visibility = ViewStates.Visible;

                editor.PutString("petSketch_username", "test_user");
                editor.PutString("petSketch_pwd", "test_pwd");
                editor.Apply();
            }


            protected override void OnResume()
            {
                base.OnResume();

            }

        
    }
   
}
