using Android.App;
using Android.Content;
using Android.OS;
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
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SsplashActivity:Activity
    {
        LinearLayout mLinearLayout;
        LinearLayout mFooterLayout;
        ImageButton im;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Drawable.activity_splash);
            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.loginlay);
            mLinearLayout.Visibility = ViewStates.Gone;

            mFooterLayout = FindViewById<LinearLayout>(Resource.Id.footer_layout);
            mFooterLayout.Visibility = ViewStates.Gone;

            im = FindViewById<ImageButton>(Resource.Id.move_button);
            var something = DoSomeTaskAsync();
           
            
            something.ContinueWith(t =>
            {


                
               

                // ResizeAnimation a = new ResizeAnimation(im);
                // a.Duration = 1000;
                // a.setParams(im.Height, 20);
                //// im.StartAnimation(a);

                // AnimationSet s = new AnimationSet(false);//false means don't share interpolators
                // s.AddAnimation(animation);
                // //s.AddAnimation(a);
                // im.StartAnimation(s);
               

            }, TaskScheduler.FromCurrentSynchronizationContext()).ContinueWith((t)=>
            {
                
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task DoSomeTaskAsync()
        {
            await Task.Delay(5000);
            PerformAnimation();
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
        }

        //private async Task DoSomeTaskAsync()
        //{

        //    return Task.Delay(5000);
        //}

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
