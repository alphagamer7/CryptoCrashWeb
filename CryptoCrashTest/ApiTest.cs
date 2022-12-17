using CryptoCrashLogic.Services;

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

        var json = "{\"status\":\"ok\",\"totalResults\":16214,\"articles\":[{\"source\":{\"id\":\"bbc-news\",\"name\":\"BBC News\"},\"urlToImage\":\"https://ichef.bbci.co.uk/news/1024/branded_news/173B1/production/_127735159_mediaitem127735158.jpg\",\"author\":\"https://www.facebook.com/bbcnews\",\"publishedAt\":\"2022-11-22T07:56:41Z\",\"title\":\"Estonian duo accused of $575m cryptocurrency scam\",\"description\":\"The men are accused of buying luxury cars after getting people to buy into fraudulent crypto mining.\"}]}";

        var res = client.CreateNewsFromJson(json);
        Console.Write(res.Count);
        Assert.IsNotNull(res);
        Assert.AreEqual(1, res.Count);
    }

}
