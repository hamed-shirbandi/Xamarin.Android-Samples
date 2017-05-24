using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;

namespace Fragments
{
    [Activity(Label = "Fragments", MainLauncher = true,Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class MainActivity : ActionBarActivity
    {
        private Fragment1 fragment1;
        private Fragment2 fragment2;
        private Fragment3 fragment3;
        private Stack<SupportFragment> stackFragments;
        private SupportFragment currentFragment;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            fragment1 = new Fragment1();
            fragment2 = new Fragment2();
            fragment3 = new Fragment3();

            stackFragments = new Stack<SupportFragment>();


            var trans = SupportFragmentManager.BeginTransaction();
            trans.Add(Resource.Id.fragment_container, fragment3, "fragment3");
            trans.Hide(fragment3);

            trans.Add(Resource.Id.fragment_container, fragment2, "fragment2");
            trans.Hide(fragment2);

            trans.Add(Resource.Id.fragment_container, fragment1, "fragment1");

            trans.Commit();

            currentFragment = fragment1;

        }


        /// <summary>
        /// 
        /// </summary>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



        /// <summary>
        /// 
        /// </summary>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.fragment1:
                    ShowFragment(fragment1);
                    break;
                case Resource.Id.fragment2:
                    ShowFragment(fragment2);
                    break;
                case Resource.Id.fragment3:
                    ShowFragment(fragment3);
                    break;
            }
            return base.OnOptionsItemSelected(item);    
        }



        /// <summary>
        /// 
        /// </summary>
        public override void OnBackPressed()
        {

            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                currentFragment = stackFragments.Pop();
            }

            else
            {
                base.OnBackPressed();
            }
        }





        /// <summary>
        /// 
        /// </summary>
  		private void ShowFragment(SupportFragment fragment)
        {
            if (fragment.IsVisible)
            {
                return;
            }

            var trans = SupportFragmentManager.BeginTransaction();

            trans.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out, Resource.Animation.slide_in, Resource.Animation.slide_out);

            fragment.View.BringToFront();
            currentFragment.View.BringToFront();

            trans.Hide(currentFragment);
            trans.Show(fragment);

            trans.AddToBackStack(null);
            stackFragments.Push(currentFragment);
            trans.Commit();

            currentFragment = fragment;
        }

    }
}

