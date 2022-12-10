using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoCrash.Areas.Identity.Data;
using CryptoCrashLogic.Services;
using CryptoCrash.Models;

namespace CryptoCrash.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly NewsApiClient<News> _newsApiClient;
        private List<News> News;

        private bool hasError = false;

        public NewsController(ApplicationDbContext context, NewsApiClient<News> newsApiClient)
        {
            _context = context;
            _newsApiClient = newsApiClient;

            try
            {
                var response = _newsApiClient.GetNews();
                News = response.Result.Take(10).ToList();
                Console.Write(News);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                hasError = true;
            }
        }



        //Added linq
        private ApplicationUser ? GetUser()
        {
            var username = User.Identity!.Name;
            return (from u in _context.Users
                    where string.Equals(username, u.UserName)
                    select u)
                .FirstOrDefault();
        }


        private List<News> GetUserReadLaterList(ApplicationUser user)
        {
            return (from n in _context.News.Include(news => news.User)
                    where string.Equals(user.UserName, n.User!.UserName)
                    select n).ToList();
        }

        public IActionResult UserReadLaterList()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            var user = GetUser();
            if (user != default(ApplicationUser))
            {
                var readLater = GetUserReadLaterList(user);
                return View(readLater);
            }
            Console.WriteLine("not authenticated");
            return View();
        }


        public IActionResult AddToReadLater(string publishedAt)
        {
            TempData["Error"] = hasError;
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            var user = GetUser();
            if (user != default(ApplicationUser))
            {
                var readLaterList = GetUserReadLaterList(user);
                var newsItem = (from m in News
                                where m.PublishedAt == publishedAt && readLaterList.Count(_news => string.Equals(_news.PublishedAt, publishedAt)) == 0
                                select m).FirstOrDefault();


                if (newsItem != default(News))
                {
                    if ((from n in _context.News where string.Equals(n.PublishedAt, publishedAt) select n).Count() == 0)
                    {
                        if (user!.ReadLaterList == null)
                        {
                            user.ReadLaterList = new List<News>();
                        }
                        // uniqueTimestamp
                        newsItem.Id = publishedAt;
                        newsItem.User = user;

                        user!.ReadLaterList!.Add(newsItem);
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("");
        }


        public IActionResult NewsList()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            TempData["Error"] = hasError;
            if (hasError)
                return View();
            return View(News);
        }

        public IActionResult Index()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            TempData["Error"] = hasError;
            if (hasError)
                return View();
            return View(News);
        }
      

        // GET: News/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,urlToImage,url,PublishedAt,Content")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Author,Description,urlToImage,url,PublishedAt,Content")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'ApplicationDbContext.News'  is null.");
            }
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(string id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
