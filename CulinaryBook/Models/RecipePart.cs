using System.Collections.Generic;

using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class RecipePart
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		[ForeignKey(typeof(Recipe))]
		public int RecipeId { get; set; }
		public string PreparationSteps { get; set; }
		[OneToMany]
		public List<Ingredient> Ingredients { get; set; }
	}
}