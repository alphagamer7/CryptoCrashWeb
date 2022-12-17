using CryptoCrash.Areas.Identity.Data;
using CryptoCrashLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using CryptoCrashLogic.Store;
using System.Collections;
using ApplicationUser = CryptoCrashLogic.Models.ApplicationUser;
using CryptoCrash.Models;

namespace CryptoCrashTest
{
    internal class DbStoreWrapper
    {

        public static News newsToAdd { get; } = new News
        {
            User = new ApplicationUser
            {
                UserName = "User3",
                PasswordHash = "231243243252dvcbfgr3",
                FirstName = "Beta",
                LastName = "Test"
            }
        };

        public static ApplicationUser user2 = new ApplicationUser
        {
            UserName = "User2",
            PasswordHash = "231243243252dvcbfgr3",
            FirstName = "Beta",
            LastName = "Test"
        };



        public static string username = "User1";
        public static News addNews { get; } = new News
        {

            Title = "Binance new offering",
            Author = "bbc",
            Description = "binance has new offering",
            urlToImage = "https://movies.universalpictures.com/media/oppenheimer-poster-560x880-62defacb1b002-1.jpg",
            PublishedAt = "2121.21.28",
            User = new ApplicationUser
            {
                UserName = "User4"
            }
        };
        public static Mock<IStore<News>> GetMock()
        {
            var mock = new Mock<IStore<News>>();

            var user1 = new ApplicationUser
            {
                UserName = "User1",
                PasswordHash = "231243243252dvcbfgr3",
                FirstName = "Beta",
                LastName = "Test"
            };



            // Setup the mock
            var news = new List<News>()
            {
                new News
                {
                        Title = "Crypto Fraud Scam",
                        Author = "bbc",
                        Description = "desc",
                        urlToImage = "https://movies.universalpictures.com/media/oppenheimer-poster-560x880-62defacb1b002-1.jpg",
                        PublishedAt ="2121.21.21",
                        User = user2
                },
            };

            mock.Setup(n => n.GetAll()).Returns(() => news);

            mock.Setup(m => m.NewsExists("2121.21.21")).Returns(() => true);
            mock.Setup(m => m.NewsExists("2121.21.13")).Returns(() => false);
            mock.Setup(m => m.AddNews(addNews)).Callback<News>((_news) => news.Add(_news));


            return mock;
        }

    }

    [TestClass]
    public class NewsControllerTests
    {
        [TestMethod]
        public void TestGetAll()
        {
            var storeWrapper = DbStoreWrapper.GetMock();
            var store = storeWrapper.Object;
            Assert.IsNotNull(store.GetAll());
            Assert.AreEqual(1, store.GetAll().Count());
        }

        [TestMethod]
        public void TestMovieExists()
        {
            var storeWrapper = DbStoreWrapper.GetMock();
            var store = storeWrapper.Object;
            Assert.IsTrue(store.NewsExists("2121.21.21"));
            Assert.IsFalse(store.NewsExists("2121.21.13"));
        }


        [TestMethod]
        public void TestAdd()
        {
            var storeWrapper = DbStoreWrapper.GetMock();
            var store = storeWrapper.Object;
            store.AddNews(DbStoreWrapper.newsToAdd);
            Assert.IsTrue(store.GetAll().Contains(DbStoreWrapper.newsToAdd));

            Assert.AreEqual(2, store.GetAll().Count());
        }
    }


}