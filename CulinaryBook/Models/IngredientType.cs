using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class IngredientType
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[ForeignKey(typeof(IngredientCategory))]
		public int IngredientCategoryId { get; set; }
		public string Name { get; set; }
	}
}