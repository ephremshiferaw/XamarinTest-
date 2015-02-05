using System;
using Android.Widget;
using Android.Content;
using Brivo.PremiseAPI.SDK.CSharp;
using Refractored.Xam.Settings;
using Android.Views;
using System.Collections.Generic;
using System.Net;

namespace OnAir
{
	public class UsersGridAdapter: BaseAdapter<string> {


		List<User> items;
	
		Android.App.Activity context;
		public UsersGridAdapter( Android.App.Activity context) : base() {
			this.context = context;
			Init ();
		}
		public override long GetItemId(int position)
		{
			return items[position].id;
		}
		public override string this[int position] {
            get { return items[position].ToString(); }
		}
		public override int Count {
			get { return items.Count; }
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
            //View view = convertView; // re-use an existing view, if one is available
            //if (view == null) // otherwise create a new one
            //    view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemSingleChoice, null);
            //view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].ToString();


            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.Users, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.name.familyName;
            view.FindViewById<TextView>(Resource.Id.Text2).Text = item.name.givenName;
           // view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;

			
		}
	


		private string _baseUrl;
		private IAuthorize _authorizer;
		private UserWrapper _wrapper;
		private QueryParameters _queryParameters;



		private void Init()
		{

            items = new List<User>();
		    for (var i = 0; i < 10; i++)
		    {
		        items.Add(new User() {id=i, name = new Name(){familyName = "LastName " + "i", givenName = "FirstName" + "i"}});
		    }

            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            _baseUrl = this.context.GetString(Resource.String.baseUrl);
            _authorizer = GetP8ApiAuthorizer();
            _queryParameters = new QueryParameters(0, 1);
            _wrapper = new UserWrapper(_authorizer, _baseUrl, _queryParameters);


            items = _wrapper.GetUsers();

		}



		private P8ApiBasedAuthorizer GetP8ApiAuthorizer()
		{
			return  new P8ApiBasedAuthorizer(
				this.context.GetString(Resource.String.p8ApiBasedAuthorizerUrl),
				this.context.GetString(Resource.String.actAsUserName),
				this.context.GetString(Resource.String.applicationId),
				this.context.GetString(Resource.String.signAlgorithm),
				this.context.GetString(Resource.String.privateKey)		
			);



		}

	}
}

