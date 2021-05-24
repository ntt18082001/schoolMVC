using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NETCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private PostRepository postRepo;
		private UnitOfWork unitOfWork;

		public HomeController(ILogger<HomeController> logger, NewsContext db)
		{
			_logger = logger;
			this.postRepo = new PostRepository(db);
			this.unitOfWork = new UnitOfWork(db);
		}
		public IActionResult Index()
		{
			List<Post> posts = unitOfWork.PostRepository.GetAll();
			return View(posts);
		}
		[Route("post/{slug}-{id:int}")]
		public ViewResult ViewPost(int id)
		{
			return View(unitOfWork.PostRepository.FindById(id));
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
