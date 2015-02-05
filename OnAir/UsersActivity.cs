
using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;


namespace OnAir
{
	[Activity (Label = "Users")]			
	public class UsersActivity : Android.App.ListActivity
	{
		string[] items;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			items = new string[] { "Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers" };
			ListAdapter = new UsersGridAdapter(this);

		}
		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
            base.OnListItemClick(l,v, position, id);
		}


	}
}

