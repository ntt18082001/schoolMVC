using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC.Models
{
	public class Post
	{
		[Key]
		public int Id { get; set; }
		[StringLength(200)]
		public string PostTitle { get; set; }
		[Column(TypeName = "ntext")]
		public string PostContent { get; set; }
		[StringLength(400)]
		public string PostTeaser { get; set; }
		public int ViewCount { get; set; }
		public int CateId { get; set; }
		[ForeignKey("CateId")]
		public virtual Category Category { get; set; }
	}
}
