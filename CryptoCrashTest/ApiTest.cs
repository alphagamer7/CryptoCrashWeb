namespace CryptoCrashTest;

[TestClass]
public class UnitTest1
{
    public class MockedResponse
        {
            public string? testString { get; set; }
        }

        [TestMethod]
        public void TestApiDeserilization()
        {
            NewsApiClient<MockedResponse> client = new();
            var json = @"{
                          'data': {
                            'upcoming': [
                              {
                                'testString': 'test1'
                              },
                              {
                                'testString': 'test2'
                              },
                                ]
                            }
                         }";
            var res = client.CreateNewsFromJson(json);
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("test1", res[0].testString);
            Assert.AreEqual("test2", res[1].testString);
        }

         [TestMethod]
        public void TestApiResponse()
        {
            MovieApiClient<MockedResponse> client = new();
            var json = @"{
                          'data': {
                            'upcoming': [
                              {
                                'testString': 'test1'
                              },
                              {
                                'testString': 'test2'
                              },
                                ]
                            }
                         }";
            var res = client.CreateNewsFromJson(json);
            Assert.IsNotNull(res);
            Assert.AreEqual(2, res.Count);
            Assert.AreEqual("test1", res[0].testString);
            Assert.AreEqual("test2", res[1].testString);
        }
}
