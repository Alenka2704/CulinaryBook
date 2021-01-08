using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class Recipe
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		[OneToMany]
		public List<Note> Notes { get; set; }
		public float Weight { get; set; }
		public string Size { get; set; }
		[ForeignKey(typeof(RecipeCategory))]
		public int RecipeCategoryId { get; set; }
		[ManyToMany(typeof(RecipeTag))]
		public List<Tag> Tags { get; set; }
	}
}