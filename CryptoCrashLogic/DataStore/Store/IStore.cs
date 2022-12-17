using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCrashLogic.Models;

namespace CryptoCrashLogic.Store
{
    public interface IStore<T>
    {
 
        public IEnumerable<News> GetAll();
        public bool NewsExists(string plublishedDate);
        public void Delete(string username, string plublishedDate);
        public ApplicationUser? GetUserByUserName(string userName);
        public List<News> GetReadListByUserName(string userName);
        public void AddNews(News news);
    
    }
}
