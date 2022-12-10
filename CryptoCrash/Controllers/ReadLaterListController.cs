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
    public class ReadLaterListController : Controller
    {

        private readonly ApplicationDbContext _context;

        private bool hasError = false;

        public ReadLaterListController(ApplicationDbContext context)
        {
            _context = context;
        
        }

        private ApplicationUser? GetUser()
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

        public IActionResult Index()
        {
            TempData["Error"] = hasError;
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
    }
}
