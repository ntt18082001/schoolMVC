﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCoreMVC.Models;

namespace NETCoreMVC.Controllers
{
    public class PostsController : Controller
    {
		//private readonly NewsContext _context;
		private readonly NewsContext _context;
		private UnitOfWork unitOfWork;
        public PostsController(NewsContext context)
        {
			_context = context;
			this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Posts
        public IActionResult Index()
        {
            //var newsContext = _context.Posts.Include(p => p.Category);
            return View(unitOfWork.PostRepository.GetAll());
        }

		//GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Posts
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (post == null)
			{
				return NotFound();
			}

			return View(post);
		}

		// GET: Posts/Create
		public IActionResult Create()
		{
			ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id");
			return View();
		}

		// POST: Posts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,PostTitle,PostContent,PostTeaser,ViewCount,CateId")] Post post)
		{
			if (ModelState.IsValid)
			{
				//_context.Add(post);
				//await _context.SaveChangesAsync();
				await unitOfWork.PostRepository.Add(post);
				await unitOfWork.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id", post.CateId);
			return View(post);
		}

		// GET: Posts/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Posts.FindAsync(id);
			if (post == null)
			{
				return NotFound();
			}
			ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id", post.CateId);
			return View(post);
		}

		// POST: Posts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,PostTitle,PostContent,PostTeaser,ViewCount,CateId")] Post post)
		{
			if (id != post.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(post);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PostExists(post.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CateId"] = new SelectList(_context.Categories, "Id", "Id", post.CateId);
			return View(post);
		}

		// GET: Posts/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var post = await _context.Posts
				.Include(p => p.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (post == null)
			{
				return NotFound();
			}

			return View(post);
		}

		// POST: Posts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var post = await _context.Posts.FindAsync(id);
			_context.Posts.Remove(post);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PostExists(int id)
		{
			return _context.Posts.Any(e => e.Id == id);
		}
	}
}
