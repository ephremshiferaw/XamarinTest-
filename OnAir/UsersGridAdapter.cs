using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Brivo.PremiseAPI.SDK.CSharp;
using Brivo.PremiseAPI.SDK.CSharp.Elements;
using Activity = Android.App.Activity;

namespace OnAir
{
    public class UsersGridAdapter : BaseAdapter<User>
    {

        private List<User> _items;
        private readonly Activity _context;

        public UsersGridAdapter(Activity context, List<User> users)
        {
            _context = context;
            _items = users;

           
        }

        public override long GetItemId(int position)
        {
            return _items[position].id;
        }

        public override User this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            var item = _items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = _context.LayoutInflater.Inflate(Resource.Layout.User, null);
			view.FindViewById<TextView>(Resource.Id.textView1).Text = getName(item);

           
            return view;


        }
		string getName(User user)
		{
			return string.Format("{0} {1}", user.name.givenName, user.name.familyName);
		}
     


    }





}



