using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace OnAir
{
	[Activity (Label = "OnAir", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Android.App.Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

		

			// Get our button from the layout resource,
			// and attach an event to it
			Button myUsers = FindViewById<Button> (Resource.Id.myUsers);
			Button myDoors = FindViewById<Button> (Resource.Id.myDoors);

		
			myUsers.Click += delegate {
				myUsersClick_Handler(myUsers);
			
			};
		}

		private void myUsersClick_Handler(Button source)
		{

			var intent = new Intent(this, typeof(UsersActivity));
			//intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
			StartActivity(intent);

			//source.Text = string.Format ("{0} clicks!", count++);
		}




	}
}


