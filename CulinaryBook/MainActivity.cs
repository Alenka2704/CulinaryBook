using System;
using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using CulinaryBook.Database;
using CulinaryBook.Models;

namespace CulinaryBook
{
	[Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
	public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
	{
		ListView lstViewData;
		List<RecipeCategory> listRecipeCategory = new List<RecipeCategory>();
		SQLiteDB db;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			SetContentView(Resource.Layout.activity_main);
			Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(toolbar);

			FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
			fab.Click += FabOnClick;

			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
			drawer.AddDrawerListener(toggle);
			toggle.SyncState();

			NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
			navigationView.SetNavigationItemSelectedListener(this);
			db = new SQLiteDB();
			db.CreateDatabase();
			lstViewData = FindViewById<ListView>(Resource.Id.listView);
			//var edtTitle = FindViewById<EditText>(Resource.Id.edtName);
			//var edtDescription = FindViewById<EditText>(Resource.Id.edtDepart);
			//var edtNotes = FindViewById<EditText>(Resource.Id.edtEmail);
			//var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
			//var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
			//var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
			//Load Data  
			LoadData();
			//Event  
			//btnAdd.Click += delegate {
			//	RecipeCategory recipe = new RecipeCategory() {
			//		Title = edtTitle.Text,
			//		Description = edtDescription.Text,
			//		PreparationSteps = edtNotes.Text
			//	};
			//	db.Insert(recipe);
			//	LoadData();
			//};
			//btnEdit.Click += delegate {
			//	RecipeCategory recipe = new RecipeCategory() {
			//		Id = int.Parse(edtTitle.Tag.ToString()),
			//		Title = edtTitle.Text,
			//		Description = edtDescription.Text,
			//		PreparationSteps = edtNotes.Text
			//	};
			//	db.Update(recipe);
			//	LoadData();
			//};
			//btnRemove.Click += delegate {
			//	RecipeCategory recipe = new RecipeCategory() {
			//		Id = int.Parse(edtTitle.Tag.ToString()),
			//		Title = edtTitle.Text,
			//		Description = edtDescription.Text,
			//		PreparationSteps = edtNotes.Text
			//	};
			//	db.Delete(recipe);
			//	LoadData();
			//};
			//lstViewData.ItemClick += (s, e) =>
			//{
			//	//Set Backround for selected item  
			//	for (int i = 0; i < lstViewData.Count; i++)
			//	{
			//		if (e.Position == i)
			//			lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
			//		else
			//			lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
			//	}
			//	//Binding Data  
			//	var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
			//	var txtDepart = e.View.FindViewById<TextView>(Resource.Id.txtView_Depart);
			//	var txtEmail = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
			//	edtTitle.Text = txtName.Text;
			//	edtTitle.Tag = e.Id;
			//	edtDescription.Text = txtDepart.Text;
			//	edtNotes.Text = txtEmail.Text;
			//};
		}

		public override void OnBackPressed()
		{
			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			if(drawer.IsDrawerOpen(GravityCompat.Start))
			{
				drawer.CloseDrawer(GravityCompat.Start);
			}
			else
			{
				base.OnBackPressed();
			}
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			int id = item.ItemId;
			if (id == Resource.Id.action_settings)
			{
				return true;
			}

			return base.OnOptionsItemSelected(item);
		}

		private void FabOnClick(object sender, EventArgs eventArgs)
		{
			View view = (View) sender;
			Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
				.SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
		}

		public bool OnNavigationItemSelected(IMenuItem item)
		{
			int id = item.ItemId;

			if (id == Resource.Id.nav_camera)
			{
				// Handle the camera action
			}
			else if (id == Resource.Id.nav_gallery)
			{

			}
			else if (id == Resource.Id.nav_slideshow)
			{

			}
			else if (id == Resource.Id.nav_manage)
			{

			}
			else if (id == Resource.Id.nav_share)
			{

			}
			else if (id == Resource.Id.nav_send)
			{

			}

			DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			drawer.CloseDrawer(GravityCompat.Start);
			return true;
		}
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		private void LoadData()
		{
			listRecipeCategory = db.SelectTable<RecipeCategory>();
			var adapter = new RecipeCategoryAdapter(this, listRecipeCategory);
			lstViewData.Adapter = adapter;
		}
	}
}