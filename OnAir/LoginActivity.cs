using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Brivo.PremiseAPI.SDK.CSharp;

namespace OnAir
{
	[Activity (Label = "OnAir", MainLauncher = true, Icon = "@drawable/icon")]
	public class LoginActivity : Activity
	{
		
	
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

		

			// Get our button from the layout resource,
			// and attach an event to it
			var logIn = FindViewById<Button> (Resource.Id.logIn);
		

		
			logIn.Click += delegate {
				logInClick_Handler(logIn);
			
			};
		}

	

		private void logInClick_Handler(Button source)
		{

			try
			{	

			 login(Resources.GetString(Resource.String.baseUrl),
								  	Resources.GetString(Resource.String.authorizerUrl),
									FindViewById<EditText> (Resource.Id.userName).Text,
									FindViewById<EditText> (Resource.Id.password).Text);


				var intent = new Intent(this, typeof(MainActivity));
				//intent.PutStringArrayListExtra("phone_numbers", _phoneNumbers);
				StartActivity(intent);
			

			//e.g Get Users
			//var users = _premiseClient.Users.GetUsers();      
			}
			catch(Exception ex) {
				Toast.MakeText(this, "invalid username or password", ToastLength.Long).Show();
			}
		}

       
		/// <summary>
		/// Login using the the specified baseUrl, authorizerUrl, userName and password.
		/// </summary>
		/// <param name="baseUrl">Base URL. eg. https://intc-premise.brivo.net/ </param>
		/// <param name="authorizerUrl">Authorizer URL. eg https://intc-premise.brivo.net/api/authenticate</param>
		/// <param name="userName">User name. eg. BrivoLabsDemo</param>
		/// <param name="password">Password. eg. brivo1</param>
		public void login(string baseUrl,string authorizerUrl,string userName,string password)
		{     
			System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };//This Line will make sure the Certificate exception is bypassed

			//Session Based Connection, so Save Client
			MyGlobals.PremiseClient =	PremiseClient.Connect(baseUrl:baseUrl, 
				userName:userName, 
				password:password,
				authorizerUrl: authorizerUrl);	
		} 


	}
	static class MyGlobals {
		public static PremiseClient PremiseClient;
	}

}


