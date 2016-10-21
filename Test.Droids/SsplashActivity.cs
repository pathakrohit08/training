using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Droids
{
   // [Activity(Theme = "@style/Theme.AppCompat.Light", MainLauncher = true, NoHistory = true)]
    public class SsplashActivity:Activity
    {
        LinearLayout mLinearLayout;
        LinearLayout mFooterLayout;
        ImageButton im;
        ISharedPreferencesEditor editor;
        ISharedPreferences prefs;
        protected override void OnCreate(Bundle bundle)
        {
           // base.OnCreate(bundle);
            SetContentView(Resource.Drawable.activity_splash);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.loginlay);
            mLinearLayout.Visibility = ViewStates.Gone;

            mFooterLayout = FindViewById<LinearLayout>(Resource.Id.footer_layout);
            mFooterLayout.Visibility = ViewStates.Gone;

            im = FindViewById<ImageButton>(Resource.Id.move_button);
            var something = DoSomeTaskAsync();

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = prefs.Edit();
            //editor.Clear();
            //editor.Commit();

            something.ContinueWith(t =>
            {
                #region old

                // StartActivity(new Intent(Application.Context, typeof(Activity1)));



                // ResizeAnimation a = new ResizeAnimation(im);
                // a.Duration = 1000;
                // a.setParams(im.Height, 20);
                //// im.StartAnimation(a);

                // AnimationSet s = new AnimationSet(false);//false means don't share interpolators
                // s.AddAnimation(animation);
                // //s.AddAnimation(a);
                // im.StartAnimation(s);

                #endregion

               

                string userName = prefs.GetString("petSketch_username", null);
                string password = prefs.GetString("petSketch_pwd", null);

                if(string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
                    PerformAnimation();
                else
                    PerformTask();

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task DoSomeTaskAsync()
        {
            await Task.Delay(5000);
            
           
        }

        private void PerformTask()
        {
           // StartActivity(new Intent(Application.Context, typeof(Activity1)));
        }

        private void PerformAnimation()
        {
            Animation animation = new TranslateAnimation(0, 0, 0, -500);

            animation.FillAfter = true;
            animation.Duration = 1000;
            animation.AnimationEnd += Animation_AnimationEnd;
            im.StartAnimation(animation);
            
            
        }

        private void Animation_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
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
    class ResizeAnimation : Animation
    {
        private int startHeight;
        private int deltaHeight; // distance between start and end height
        private ImageButton view;

        public ResizeAnimation(ImageButton v)
        {
            this.view = v;
        }

        protected override void ApplyTransformation(float interpolatedTime, Transformation t)
        {
            view.LayoutParameters.Height = (int)(startHeight + deltaHeight * interpolatedTime);
            view.RequestLayout();
        }
        public void setParams(int start, int end)
        {

            this.startHeight = start;
            deltaHeight = end - startHeight;
        }

    }
}
