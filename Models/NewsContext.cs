using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC.Models
{
	public class NewsContext : DbContext
	{
		public NewsContext(DbContextOptions<NewsContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Post> Posts { get; set; }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=LAPTOP-BKICATJ7\\SQLEXPRESS;Initial Catalog=NewsCoreMVC;Integrated Security=True");
		//}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>()
				.HasKey(x => x.Id);
			/*Id tự tăng*/
			modelBuilder.Entity<Post>(x => {
				x.HasKey(a => a.Id);
				x.Property(a => a.Id).ValueGeneratedOnAdd();
			});
			modelBuilder.Entity<Category>()
				.HasKey(x => x.Id);
			modelBuilder.Entity<Category>()
				.HasMany(x => x.Posts)
				.WithOne(x => x.Category);
			modelBuilder.Entity<Post>()
				.Property(x => x.ViewCount)
				.HasDefaultValue(0);
		}
	}
}
