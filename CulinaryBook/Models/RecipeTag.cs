using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class RecipeTag
    {
        [ForeignKey(typeof(Recipe))]
        public int RecipeId { get; set; }
        [ForeignKey(typeof(Tag))]
        public int TagId { get; set; }
    }
}