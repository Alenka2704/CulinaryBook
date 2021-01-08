﻿using SQLite;

namespace CulinaryBook.Models
{
	public class Tag
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}