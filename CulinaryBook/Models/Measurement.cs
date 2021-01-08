using SQLite;

namespace CulinaryBook.Models
{
	public class Measurement
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Label { get; set; }
		public float Mililiters { get; set; }
		public float Grams { get; set; }
	}
}