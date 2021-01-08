using SQLite;

namespace CulinaryBook.Models
{
	public class RecipeCategory
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}