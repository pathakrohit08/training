using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
//using MyTrains.Core.ViewModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Test.Droids
{

    [Activity(Label = "Main Activity", Theme = "@style/AppTheme",
      LaunchMode = LaunchMode.SingleTop,
      ScreenOrientation = ScreenOrientation.Portrait,
      Name = "mytrains.droid.activities.MainActivity")]
    public class Activity1 : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        static readonly string TAG = "X:" + typeof(Activity1).Name;
        private DrawerLayout _drawerLayout;
        private MvxActionBarDrawerToggle _drawerToggle;
        private FragmentManager _fragmentManager;

        internal DrawerLayout DrawerLayout { get { return _drawerLayout; } }

        static Activity1 instance = new Activity1();

        public static Activity1 CurrentActivity => instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _fragmentManager = FragmentManager;

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            _drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow_light, (int)GravityFlags.Start);
            _drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout,
                                Resource.String.drawer_open, Resource.String.drawer_close);
            _drawerToggle.DrawerClosed += _drawerToggle_DrawerClosed;
            _drawerToggle.DrawerOpened += _drawerToggle_DrawerOpened;

            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            _drawerToggle.DrawerIndicatorEnabled = true;
            _drawerLayout.SetDrawerListener(_drawerToggle);

            #region old

            //ImageButton im = FindViewById<ImageButton>(Resource.Id.move_button);
            ////set position TranslateAnimation(float fromXDelta, float toXDelta, float fromYDelta, float toYDelta
            //Animation animation = new TranslateAnimation(0, 500, 0, 0);
            //// set Animation for 5 sec
            //animation.Duration = 1000;
            ////for button stops in the new position.
            //animation.FillAfter = true;
            //im.StartAnimation(animation);


            //mLinearLayout = FindViewById<LinearLayout>(Resource.Id.expandable);
            //mLinearLayout.Visibility = ViewStates.Gone;
            //mLinearLayoutHeader = FindViewById<LinearLayout>(Resource.Id.header);
            //mLinearLayoutHeader.Click += (s, e) =>
            //{
            //    if (mLinearLayout.Visibility.Equals(ViewStates.Gone))
            //    {
            //        //set Visible
            //        mLinearLayout.Visibility = ViewStates.Visible;
            //        int widthSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
            //        int heightSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
            //        mLinearLayout.Measure(widthSpec, heightSpec);

            //        ValueAnimator mAnimator = slideAnimator(0, mLinearLayout.MeasuredHeight);
            //        mAnimator.Start();

            //    }
            //    else
            //    {
            //        //collapse();
            //        int finalHeight = mLinearLayout.Height;

            //        ValueAnimator mAnimator = slideAnimator(finalHeight, 0);
            //        mAnimator.Start();
            //        mAnimator.AnimationEnd += (object IntentSender, EventArgs arg) => {
            //            mLinearLayout.Visibility = ViewStates.Gone;
            //        };
            //    }
            //};

            #endregion

            Log.Debug(TAG, "Activity1 is loaded.");
        }

        private void _drawerToggle_DrawerOpened(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }

        private void _drawerToggle_DrawerClosed(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }

        public override void OnBeforeFragmentChanging(IMvxCachedFragmentInfo fragmentInfo, Android.Support.V4.App.FragmentTransaction transaction)
        {
            var currentFrag = SupportFragmentManager.FindFragmentById(Resource.Id.content_frame) as MvxFragment;

            if (currentFrag != null && fragmentInfo.ViewModelType != typeof(MenuViewModel)
                && currentFrag.FindAssociatedViewModelType() != fragmentInfo.ViewModelType)
                fragmentInfo.AddToBackStack = true;
            base.OnBeforeFragmentChanging(fragmentInfo, transaction);
        }

        internal void CloseDrawerMenu()
        {
            _drawerLayout.CloseDrawers();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.SyncState();
        }
        #region old
        //private ValueAnimator slideAnimator(int start, int end)
        //{

        //    ValueAnimator animator = ValueAnimator.OfInt(start, end);
        //    animator.Update +=
        //        (object sender, ValueAnimator.AnimatorUpdateEventArgs e) => {
        //        var value = (int)animator.AnimatedValue;
        //            ViewGroup.LayoutParams layoutParams = mLinearLayout.LayoutParameters;
        //            layoutParams.Height = value;
        //            mLinearLayout.LayoutParameters = layoutParams;

        //        };
        //    return animator;
        //}

        #endregion
    }
    public class MainViewModel : MvxViewModel
    {

    }
    public class MenuViewModel
    {
    }
}
