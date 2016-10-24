
using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using MvvmCross.Droid.Shared.Caching;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MyTrains.Core.ViewModel;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;

namespace Test.Droids.Activities
{
    [Activity(Label = "Main Activity", Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop,
        ScreenOrientation = ScreenOrientation.Portrait,
        Name = "test.droids.activities.MainActivity")]
    public class MainActivity : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        
        private MvxActionBarDrawerToggle _drawerToggle;
        private FragmentManager _fragmentManager;
        Fragment[] _fragments;
        private ActionBar ab;
        TabHost host;

        

        static MainActivity instance = new MainActivity();

        public static MainActivity CurrentActivity => instance;

        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _fragmentManager = FragmentManager;
            SetContentView(Resource.Layout.MainView);

             //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
             host= FindViewById<TabHost>(Resource.Id.tabhost);

            #region old
            //SetSupportActionBar(toolbar);

            //_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            //_drawerLayout.SetDrawerShadow(Resource.Drawable.drawer_shadow_light, (int)GravityFlags.Start);
            //_drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout,
            //                    Resource.String.drawer_open, Resource.String.drawer_close);
            //_drawerToggle.DrawerClosed += _drawerToggle_DrawerClosed;
            //_drawerToggle.DrawerOpened += _drawerToggle_DrawerOpened;

            //SupportActionBar.SetDisplayShowTitleEnabled(false);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //_drawerToggle.DrawerIndicatorEnabled = true;
            //_drawerLayout.SetDrawerListener(_drawerToggle);

            // ViewModel.ShowMenu();
            // ViewModel.ShowSearchJourneys();

            //this.ActionBar.SetDisplayShowHomeEnabled(false);
            //this.ActionBar.SetDisplayShowTitleEnabled(false);
            ////ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            //ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;


            //_fragments = new Fragment[]
            //             {
            //                 new WhatsOnFragment(),
            //                 new SpeakersFragment(),
            //                 new SessionsFragment()
            //             };

            //AddTabToActionBar(Resource.String.whatson_tab_label, Resource.Drawable.ic_action_whats_on);
            //AddTabToActionBar(Resource.String.speakers_tab_label, Resource.Drawable.ic_action_speakers);
            //AddTabToActionBar(Resource.String.sessions_tab_label, Resource.Drawable.ic_action_sessions);

            #endregion
            

            
        }

     

        void AddTabToActionBar(int labelResourceId, int iconResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                                         .SetText(labelResourceId)
                                         .SetIcon(iconResourceId);
            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab)sender;

            Fragment frag = _fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.content_frame, frag);
        }

        private void _drawerToggle_DrawerOpened(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }

        private void _drawerToggle_DrawerClosed(object sender, ActionBarDrawerEventArgs e)
        {
            InvalidateOptionsMenu();
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            //if (_drawerToggle.OnOptionsItemSelected(item))
            //{
            //    return true;
            //}

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
          //  _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
           // _drawerToggle.SyncState();
        }

        
    }
    
}
