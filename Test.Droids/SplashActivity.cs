using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views.Animations;
using Android.Widget;
using System.Threading.Tasks;
using static Android.Locations.GpsStatus;
using static Android.Resource;
using System;
using Android.Graphics.Drawables;
using Android.Content.PM;

namespace Test.Droids
{
   // [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            
        }

      
        protected override void OnResume()
        {
            base.OnResume();

          
            Task startupWork = new Task(() =>
            {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                Task.Delay(5000); // Simulate a bit of startup work.
                Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t =>
            {
                Log.Debug(TAG, "Work is finished - start Activity1.");
                StartActivity(new Intent(Application.Context, typeof(Activity1)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

        //private void btn_Click(object sender, System.EventArgs e)
        //{
        //    TextView txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);
        //    Button b = sender as Button;
        //    Android.Views.Animations.Animation anim = AnimationUtils.LoadAnimation(ApplicationContext,
        //                   Resource.Animation.fade_in);
        //    txtMessage.StartAnimation(anim);
        //}

       
    }
}
