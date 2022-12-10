using System;
using CryptoCrashLogic;
using CryptoCrashLogic.Services;

namespace CryptoCrashTest
{
    [TestClass]
    public class UnitTestLogic
    {
        NewsApiClient<News> newApiClient;

        public UnitTestLogic()
        {
        }

        [TestInitialize]
        public void Instantiate()
        {
            newApiClient = new NewsApiClient<News>();
        }

        [TestMethod]
        public void NewsClientClassIsInstantiable()
        {
            Assert.IsNotNull(newApiClient);
        }

    }
}

