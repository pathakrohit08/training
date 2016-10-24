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

        ImageButton im;
        ISharedPreferencesEditor editor;
        ISharedPreferences prefs;

        LinearLayout register_layout;
        LinearLayout internet_missing;
        LinearLayout login_layout;
        LinearLayout footer_layout;
        TextView register_text;
        Button register_btn;
        public new SplashViewModel ViewModel
        {
            get { return (SplashViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SplashView);

            #region old

            //mLinearLayout = FindViewById<LinearLayout>(Resource.Id.login_layout);
            //mLinearLayout.Visibility = ViewStates.Gone;

            //mFooterLayout = FindViewById<LinearLayout>(Resource.Id.footer_layout);
            //mFooterLayout.Visibility = ViewStates.Gone;

            //includedLayout = FindViewById<LinearLayout>(Resource.Id.internet_retry);
            //includedLayout.Visibility = ViewStates.Gone;
            //im = FindViewById<ImageButton>(Resource.Id.move_button);
            //    var something = DoSomeTaskAsync();

            //    prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            //    editor = prefs.Edit();
            //    editor.Clear();
            //    editor.Commit();
            #endregion

            AllocateRegions();

            var something = DoSomeTaskAsync();

        }

        private void AllocateRegions()
        {
            login_layout = FindViewById<LinearLayout>(Resource.Id.login_layout);
            login_layout.Visibility = ViewStates.Gone;

            register_layout = FindViewById<LinearLayout>(Resource.Id.register_layout);
            register_layout.Visibility = ViewStates.Gone;

            internet_missing = FindViewById<LinearLayout>(Resource.Id.internet_retry);
            internet_missing.Visibility = ViewStates.Gone;

            footer_layout = FindViewById<LinearLayout>(Resource.Id.footer_layout);
            footer_layout.Visibility = ViewStates.Gone;

            im = FindViewById<ImageButton>(Resource.Id.move_button);


            register_text = FindViewById<TextView>(Resource.Id.account_text);
            register_text.Click += (s, e) =>
            {
                login_layout.Visibility = ViewStates.Gone;
                register_layout.Visibility = ViewStates.Visible;
                footer_layout.Visibility = ViewStates.Gone;
            };

            register_btn = FindViewById<Button>(Resource.Id.signup_btn);
            register_btn.Click += (s, e) =>
            {
                login_layout.Visibility = ViewStates.Visible;
                register_layout.Visibility = ViewStates.Gone;
                footer_layout.Visibility = ViewStates.Visible;
            };
        }

        private async Task DoSomeTaskAsync()
        {
            await Task.Delay(1000);
            PerformAnimation();
            // PerformTask();


        }

        private void PerformTask()
        {

            base.ViewModel.NavigateToMainView.Execute();

        }

        private void PerformAnimation()
        {

            Animation logoMoveAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.test_anim);
            im.StartAnimation(logoMoveAnimation);
            logoMoveAnimation.AnimationEnd += Animation_AnimationEnd;

        }

        private void Animation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {

            login_layout.Visibility = ViewStates.Visible;
            footer_layout.Visibility = ViewStates.Visible;
        }


        protected override void OnResume()
        {
            base.OnResume();

        }


    }
   
}
