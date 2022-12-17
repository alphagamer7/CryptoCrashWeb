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
    public void TestNewsApiDeserilization()
    {
        NewsApiClient<MockedResponse> client = new();

        var json = "{\"status\":\"ok\",\"totalResults\":16214,\"articles\":[{\"source\":{\"id\":\"bbc-news\",\"name\":\"BBC News\"},\"urlToImage\":\"https://ichef.bbci.co.uk/news/1024/branded_news/173B1/production/_127735159_mediaitem127735158.jpg\",\"author\":\"https://www.facebook.com/bbcnews\",\"publishedAt\":\"2022-11-22T07:56:41Z\",\"title\":\"Estonian duo accused of $575m cryptocurrency scam\",\"description\":\"The men are accused of buying luxury cars after getting people to buy into fraudulent crypto mining.\"}]}";

        var res = client.CreateNewsFromJson(json);
        Console.Write(res.Count);
        Assert.IsNotNull(res);
        Assert.AreEqual(1, res.Count);
    }


    [TestMethod]
    public void TestCryptoApiDeserilization()
    {
        CryptoApiClient<MockedResponse> client = new();

        var json = @"{
           'asset_id':'USD',
           'name':'US Dollar',
           'type_is_crypto': 0,
           'data_quote_start':'2014-02-24T17:43:05.0000000Z',
           'data_quote_end':'2022-12-16T00:00:00.0000000Z',
           'data_orderbook_start':'2014-02-24T17:43:05.0000000Z',
           'data_orderbook_end':'2022-12-16T00:00:00.0000000Z',
           'data_trade_start':'2010-07-17T23:09:17.0000000Z',
           'data_trade_end':'2022-12-16T00:00:00.0000000Z',
           'data_symbols_count': 155998,
           'volume_1hrs_usd': 2920897509095.92,
           'volume_1day_usd': 19385713113168.77,
           'volume_1mth_usd': 528580438329131.05,
           'id_icon':'0a4185f2-1a03-4a7c-b866-ba7076d8c73b',
           'data_start':'2010-07-17',
           'data_end':'2022-12-16'
    }";

        var res = client.CreateCryptoListFromJson(json);
        Console.Write(res.Count);
        Assert.IsNotNull(res);
   
    }



}
