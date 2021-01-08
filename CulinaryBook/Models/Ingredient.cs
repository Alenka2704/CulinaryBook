using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class Ingredient
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[ForeignKey(typeof(IngredientType))]
		public int IngredientTypeId { get; set; }
		[ForeignKey(typeof(RecipePart))]
		public int RecipePartId { get; set; }
		[ForeignKey(typeof(Measurement))]
		public int MeasuremetId { get; set; }
		public float Amount { get; set; }
	}
}