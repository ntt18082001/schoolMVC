using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC
{
	public interface IRepository<T>
	{
		Task Add(T entity);
		bool Exist(int id);
		Task Update(T entity);
		Task Remove(int id);
		T FindById(int id);
		List<T> GetAll();
	}
}
