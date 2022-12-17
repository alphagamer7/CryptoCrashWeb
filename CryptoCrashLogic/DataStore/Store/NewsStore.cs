using CryptoCrashLogic.DataStore;
using CryptoCrashLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCrashLogic.Store
{
    public class NewsStore : IStore<News>
    {
        private readonly ApplicationDbContext _db;

        public NewsStore(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddNews(News news)
        {
            if (!NewsExists(news.PublishedAt!))
            {
                news.User!.ReadLaterList!.Add(news);
                _db.SaveChanges();
            }
        }

        public bool NewsExists(string PublishedAt)
        {
            return (from m in _db.News where string.Equals(m.PublishedAt, PublishedAt) select m).Count() != 0;
        }

        public void Delete(string username, string publishedAt)
        {
            var user = GetUserByUserName(username);
            if (user != default(ApplicationUser))
            {
                var news = user!.ReadLaterList!.FirstOrDefault(news => news.PublishedAt!.Equals(publishedAt));

                if (news != default(News))
                {
                    _db.News.Remove(news);
                    user!.ReadLaterList!.Remove(news);
                    _db.SaveChanges();
                }
            }
        }

        public IEnumerable<News> GetAll()
        {
            return _db.News;
        }

        public ApplicationUser? GetUserByUserName(string userName)
        {
            return (from u in _db.Users
                    where string.Equals(userName, u.UserName)
                    select u)
                .FirstOrDefault();
        }

        public List<News> GetReadListByUserName(string userName)
        {
            return (from n in _db.News.Include(news => news.User)
                    where string.Equals(userName, n.User!.UserName)
                    select n).ToList();
        }

 
    }
}
