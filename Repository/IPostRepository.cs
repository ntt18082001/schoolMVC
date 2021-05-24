using Microsoft.EntityFrameworkCore;
using NETCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC
{
	public interface IPostRepository
	{
		Task Add(Post post);
		bool Exist(int id);
		Task Update(Post post);
		Task Remove(int id);
		Post FindById(int id);
		List<Post> GetAll();
	}
	public class PostRepository : IPostRepository
	{
		private NewsContext db;
		public PostRepository(NewsContext _db)
		{
			this.db = _db;
		}
		public async Task Add(Post post)
		{
			await db.AddAsync(post);
		}

		public bool Exist(int id)
		{
			Post post = db.Posts.Find(id);
			if(post != null)
			{
				return true;
			}
			return false;
		}

		public Post FindById(int id)
		{
			Post post = db.Posts.Find(id);
			return post;
		}

		public List<Post> GetAll()
		{
			return db.Posts.ToList();
		}

		public async Task Remove(int id)
		{
			Post post = await db.Posts.FindAsync(id);
			db.Posts.Remove(post);
			//await db.SaveChangesAsync();
		}

		public async Task Update(Post post)
		{
			Post post2 = await db.Posts.FindAsync(post.Id);
			post2 = post;
			//await db.SaveChangesAsync();
		}
	}
}
