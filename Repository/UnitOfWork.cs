using NETCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC
{
	public class UnitOfWork
	{
		private NewsContext db;
		private CateRepository cate;
		private PostRepository post;
		public UnitOfWork(NewsContext _db)
		{
			this.db = _db;
		}
		public CateRepository CateRepository
		{
			get
			{
				if (cate == null)
				{
					cate = new CateRepository(db);
				}
				return this.cate;
			}
		}
		public PostRepository PostRepository
		{
			get
			{
				if (post == null)
				{
					post = new PostRepository(db);
				}
				return this.post;
			}
		}
		public async Task SaveChanges()
		{
			await db.SaveChangesAsync();
		}
	}
}
