using Android.App;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Animation;
using Android.Views.Animations;

namespace Test.Droids
{

    [Activity(Label = "@string/ApplicationName")]
    public class Activity1: Activity 
    {
        static readonly string TAG = "X:" + typeof(Activity1).Name;
        Button _button;
        int _clickCount;
        LinearLayout mLinearLayout;
        LinearLayout mLinearLayoutHeader;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            ImageButton im = FindViewById<ImageButton>(Resource.Id.move_button);
            //set position TranslateAnimation(float fromXDelta, float toXDelta, float fromYDelta, float toYDelta
            Animation animation = new TranslateAnimation(0, 500, 0, 0);
            // set Animation for 5 sec
            animation.Duration = 1000;
            //for button stops in the new position.
            animation.FillAfter = true;
            im.StartAnimation(animation);


            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.expandable);
            mLinearLayout.Visibility = ViewStates.Gone;
            mLinearLayoutHeader = FindViewById<LinearLayout>(Resource.Id.header);
            mLinearLayoutHeader.Click += (s, e) =>
            {
                if (mLinearLayout.Visibility.Equals(ViewStates.Gone))
                {
                    //set Visible
                    mLinearLayout.Visibility = ViewStates.Visible;
                    int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
                    mLinearLayout.Measure(widthSpec, heightSpec);

                    ValueAnimator mAnimator = slideAnimator(0, mLinearLayout.MeasuredHeight);
                    mAnimator.Start();

                }
                else
                {
                    //collapse();
                    int finalHeight = mLinearLayout.Height;

                    ValueAnimator mAnimator = slideAnimator(finalHeight, 0);
                    mAnimator.Start();
                    mAnimator.AnimationEnd += (object IntentSender, EventArgs arg) => {
                        mLinearLayout.Visibility = ViewStates.Gone;
                    };
                }
            };
            Log.Debug(TAG, "Activity1 is loaded.");
        }
        private ValueAnimator slideAnimator(int start, int end)
        {

            ValueAnimator animator = ValueAnimator.OfInt(start, end);
            animator.Update +=
                (object sender, ValueAnimator.AnimatorUpdateEventArgs e) => {
                var value = (int)animator.AnimatedValue;
                    ViewGroup.LayoutParams layoutParams = mLinearLayout.LayoutParameters;
                    layoutParams.Height = value;
                    mLinearLayout.LayoutParameters = layoutParams;

                };
            return animator;
        }
    }
}
