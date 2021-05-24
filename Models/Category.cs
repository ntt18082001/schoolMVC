using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC.Models
{
	public class Category
	{
		public Category()
		{
			Posts = new HashSet<Post>();
		}
		[Key]
		public int Id { get; set; }
		[StringLength(20)]
		public string CategoryName { get; set; }
		public ICollection<Post> Posts { get; set; }
	}
}
