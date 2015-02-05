using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace OnAir
{
	[Activity (Label = "OnAir", Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

		

			// Get our button from the layout resource,
			// and attach an event to it
			var myUsers = FindViewById<Button> (Resource.Id.myUsers);
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

        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

        //private MobileServiceUser user;
        ////Mobile Service Client reference
        //private MobileServiceClient client;

        //private async Task Authenticate()
        //{
        //    try
        //    {
        //        user = await client.LoginAsync(this, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
        //        CreateAndShowDialog(string.Format("you are now logged in - {0}", user.UserId), "Logged in!");
        //    }
        //    catch (Exception ex)
        //    {
        //        CreateAndShowDialog(ex, "Authentication failed");
        //    }
        //}



	}
}


