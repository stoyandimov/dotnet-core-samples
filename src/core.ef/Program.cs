using System;

namespace core.ef
{
	class Program
	{
		static void Main(string[] args)
		{
			// Prpeare the DB:
			//  Add-Migration InitialMigration
			//  Update-Database
			// Follow this for ef on linux https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
			using (var db = new BloggingContext())
			{
				// db.Blogs.Add(new Blog() { Url = "blog.example.com" });
				// db.SaveChanges();

				foreach (Blog b in db.Blogs)
				{
					Console.WriteLine($" - {b.Url}");
				}
			}

			Console.ReadLine();
		}
	}
}
