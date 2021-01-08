using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

using CulinaryBook.Models;

namespace CulinaryBook.Database
{
	public class ViewHolder : Java.Lang.Object
	{
		public TextView txtTitle { get; set; }
	}

	public class RecipeCategoryAdapter : BaseAdapter
	{
		private Activity activity;
		private List<RecipeCategory> listRecipeCategory;
		public RecipeCategoryAdapter(Activity activity, List<RecipeCategory> listRecipe)
		{
			this.activity = activity;
			this.listRecipeCategory = listRecipe;
		}
		public override int Count
		{
			get { return listRecipeCategory.Count; }
		}
		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}
		public override long GetItemId(int position)
		{
			return listRecipeCategory[position].Id;
		}
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.RecipeCategoryShow, parent, false);
			var txtViewRecipeCategoryName = view.FindViewById<TextView>(Resource.Id.txtIngredientCategory_Name);
			txtViewRecipeCategoryName.Text = listRecipeCategory[position].Name;
			return view;
		}
	}
}