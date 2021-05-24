using Microsoft.EntityFrameworkCore;
using NETCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC
{
	public class CateRepository : IRepository<Category>
	{
		private NewsContext db;
		public CateRepository(NewsContext _db)
		{
			this.db = _db;
		}
		public async Task Add(Category entity)
		{
			await db.AddAsync(entity);
		}

		public bool Exist(int id)
		{
			Category category = db.Categories.Find(id);
			if(category != null)
			{
				return true;
			}
			return false;
		}

		public Category FindById(int id)
		{
			return db.Categories.Find(id);
		}

		public List<Category> GetAll()
		{
			return db.Categories.ToList();
		}

		public async Task Remove(int id)
		{
			Category category = await db.Categories.FindAsync(id);
			db.Categories.Remove(category);
		}

		public async Task Update(Category entity)
		{
			Category category = await db.Categories.FindAsync(entity.Id);
			category = entity;
		}
	}
}
