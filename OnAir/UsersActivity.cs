
using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Brivo.PremiseAPI.SDK.CSharp.Elements;
using Activity = Android.App.Activity;

namespace OnAir
{
	[Activity(Label = "Users", Icon = "@drawable/icon")]
    public class UsersActivity : Activity, AdapterView.IOnItemLongClickListener
    {



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Users);
            Init();
            var listView = (ListView) FindViewById(Resource.Id.listView1);
            listView.Adapter = new UsersGridAdapter(this, _items);
            var myFilter = (EditText) FindViewById(Resource.Id.myFilter);

            myFilter.TextChanged += (sender, args) =>
            {
                var filterd =
                    _items.Where(item => item.name.givenName.StartsWith(myFilter.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                listView.Adapter = new UsersGridAdapter(this, filterd);
            };


            RegisterForContextMenu(listView);

           // listView.OnItemLongClickListener = this;


        }



        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            if (v.Id == Resource.Id.listView1)
            {
                var info = (AdapterView.AdapterContextMenuInfo)menuInfo;

                var status = _items[info.Position].status;
                var menuItems = new List<string> {"Details", status == "Active" ? "Suspend" : "Activate"};

                //  menu.SetHeaderTitle(_items[info.Position].ToString());
              
                for (var i = 0; i < menuItems.Count; i++)
                    menu.Add(Menu.None, i, i, menuItems[i]);
            }
        }
        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            var menuItemIndex = item.ItemId;
            var listItemName = _items[info.Position];
            var menuItems = new List<string> { "Details", listItemName.status == "Active" ? "Suspend" : "Activate" };
            var menuItemName = menuItems[menuItemIndex];


            Toast.MakeText(this, string.Format("Selected {0} for item {1}", menuItemName, listItemName), ToastLength.Short).Show();

            listItemName.status = listItemName.status == "Active" ? "Suspended" : "Active";
            return true;
        }
        private List<User> _items;

        private void Init()
        {




			_items = MyGlobals.PremiseClient.Users.GetUsers ();

			/*
            _items = new List<User>
            {
                new User() {status="Active", id= 1, firstName = "John", lastName = "Williams"},
                new User() {status="Active", id= 2, firstName = "Antonio", lastName = "Walker"},
                new User() {status="Active", id= 3, firstName = "Teresa", lastName = "Anderson"},
                new User() {status="Active", id= 4, firstName = "Diana", lastName = "Harrison"},
                new User() {status="Active", id= 5, firstName = "Andrew", lastName = "Fox"},
                new User() {status="Active", id= 6, firstName = "Walter", lastName = "Morris"},
                new User() {status="Active", id= 7, firstName = "Jessica", lastName = "Alexander"},
                new User() {status="Active", id= 8, firstName = "Ashley", lastName = "Mills"},
                new User() {status="Active", id= 9, firstName = "Daniel", lastName = "Smith"},
                new User() {status="Active", id= 10, firstName = "Louis", lastName = "Little"},
                new User() {status="Active", id= 11, firstName = "Bonnie", lastName = "Simmons"},
                new User() {status="Active", id= 12, firstName = "Gary", lastName = "Boyd"},
                new User() {status="Active", id= 13, firstName = "Jane", lastName = "Carter"},
                new User() {status="Active", id= 14, firstName = "Bonnie", lastName = "Carpenter"},
                new User() {status="Active", id= 15, firstName = "Brian", lastName = "Jenkins"},
                new User() {status="Active", id= 16, firstName = "Diana", lastName = "Harper"},
                new User() {status="Active", id= 17, firstName = "John", lastName = "Howell"},
                new User() {status="Active", id= 18, firstName = "Christopher", lastName = "Cunningham"},
                new User() {status="Active", id= 19, firstName = "Jesse", lastName = "Patterson"},





            };
*/
            // items =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(this.context.GetString(Resource.String.sample));



            //for (var i = 0; i < 10; i++)
            //{
            //    items.Add(new User() {id=i, name = new Name(){fir = "LastName " + "i", givenName = "FirstName" + "i"}});
            //}

            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };




            //items = _wrapper.GetUsers ();

        }

       

        bool AdapterView.IOnItemLongClickListener.OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            var listView = (ListView) FindViewById(Resource.Id.listView1);
            var item = listView.GetItemAtPosition(position);

            //  var toggleButton = item.FindViewById<ToggleButton>(Resource.Id.toggleButton1);

            var builder = new AlertDialog.Builder(this);
            var alertDialog = builder.Create();
            alertDialog.SetTitle("?");
            alertDialog.SetMessage("Are you sure you want to  " + item.ToString());
            alertDialog.SetButton("Yes", (s, ev) =>
            {
                alertDialog.Hide();
            });

            alertDialog.SetButton2("No", (s, ev) =>
            {
                alertDialog.Hide();
            });
            alertDialog.Show();

            return true;
        }
    }

}

