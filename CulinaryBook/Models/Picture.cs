using System;

using SQLite;

using SQLiteNetExtensions.Attributes;

namespace CulinaryBook.Models
{
	public class Picture
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[ForeignKey(typeof(RecipePart))]
		public int NoteId { get; set; }
		public DateTime Date { get; set; }
		public byte[] Image { get; set; }
	}
}