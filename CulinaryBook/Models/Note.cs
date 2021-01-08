using System;
using System.Collections.Generic;

using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class Note
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[ForeignKey(typeof(Recipe))]
		public int RecipeId { get; set; }
		public DateTime Date { get; set; }
		public string Coment { get; set; }
		[OneToMany]
		public List<Picture> Pictures { get; set; }
	}
}