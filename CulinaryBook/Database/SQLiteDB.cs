using Android.Util;

using CulinaryBook.Models;

using SQLite;

using SQLiteNetExtensions.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
namespace CulinaryBook.Database
{
	public class SQLiteDB
	{
		string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		public bool CreateDatabase()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					connection.CreateTable<Ingredient>();
					connection.CreateTable<IngredientCategory>();
					connection.CreateTable<IngredientType>();
					connection.CreateTable<Measurement>();
					connection.CreateTable<Note>();
					connection.CreateTable<Picture>();
					connection.CreateTable<Recipe>();
					connection.CreateTable<RecipeCategory>();
					connection.CreateTable<RecipePart>();
					connection.CreateTable<RecipeTag>();
					connection.CreateTable<Tag>();
					return true;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public T Select<T>(int id) where T : new()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					return connection.GetWithChildren<T>(id);
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return default;
			}
		}

		public List<T> SelectTable<T>() where T : new()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					return connection.GetAllWithChildren<T>();
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
		}

		public bool Insert(object record)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					connection.Insert(record);
					return true;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public bool Update(object record)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					//switch (record)
					//{
					//	case Recipe recipe:
					//		connection.Query<Recipe>("UPDATE Recipe set Title=?, Description=?, PreparationSteps=?, Notes=?, Size=?, Weight=? Where Id=?", recipe.Title, recipe.Description, recipe.PreparationSteps, recipe.Notes, recipe.Size, recipe.Weight, recipe.Id);
					//		break;
					//	default:
					//		break;
					//}
					connection.UpdateWithChildren(record);
					return true;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public bool Delete(object record)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Recipes.db")))
				{
					connection.Delete(record);
					return true;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}
	}
}