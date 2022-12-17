using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoCrash;
using CryptoCrash.Controllers;

namespace CryptoCrashTest
{
        [TestClass]
        public class NewsControllerTest
        {
            [TestMethod]
            public void TestDetailsView()
            {
                var controller = new NewsController();
                var result = controller.Details(2) as ViewResult;
                Assert.AreEqual("Details", result.ViewName);

            }
        }
    }
}
