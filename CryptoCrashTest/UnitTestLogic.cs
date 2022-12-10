using System;
using CryptoCrashLogic.Services;

namespace CryptoCrashTest
{
    [TestClass]
    public class UnitTestLogic
    {
        NewsApiClient newApiClient;

        public UnitTestLogic()
        {
        }

        [TestInitialize]
        public void Instantiate()
        {
            newApiClient = new NewsApiClient();
        }

        [TestMethod]
        public void NewsClientClassIsInstantiable()
        {
            Assert.IsNotNull(newApiClient);
        }

    }
}

