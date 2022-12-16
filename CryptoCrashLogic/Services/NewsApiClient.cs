using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CryptoCrashLogic.Services
{
    public class NewsApiClient<T>
    {
        private readonly HttpClient client;
   

        public NewsApiClient()
        {
            client = new();
        }

        public static string newsUrl =
            "https://newsapi.org/v2/everything?q=cryptocurrency&apiKey=D08d6b3c579542f0abbae1f6a3c3949a&page=1";


        public async Task<List<T>> GetNews()
        {
            HttpResponseMessage response = await client.GetAsync(newsUrl);

            var json2 = "{\"status\":\"ok\",\"totalResults\":16214,\"articles\":[{\"source\":{\"id\":\"bbc-news\",\"name\":\"BBC News\"},\"urlToImage\":\"https://ichef.bbci.co.uk/news/1024/branded_news/173B1/production/_127735159_mediaitem127735158.jpg\",\"author\":\"https://www.facebook.com/bbcnews\",\"publishedAt\":\"2022-11-22T07:56:41Z\",\"title\":\"Estonian duo accused of $575m cryptocurrency scam\",\"description\":\"The men are accused of buying luxury cars after getting people to buy into fraudulent crypto mining.\"}]}";

            var body =  response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : json2; // since sometimes api timeouts
   
            return CreateNewsFromJson(body);
        }

        public List<T> CreateNewsFromJson(string json)
        {
            var res = JsonConvert.DeserializeObject<Response<T>>(json);
            return res?.articles!;
        }

    }

    
    public class Response<T>
    {
        [Required]
        public List<T> articles { get; set; }
    }
    public class Data<T>
    {
        [Required]
        public List<T> articles { get; set; }
    }
}



public class NewsResponse
    {
        public string status { get; set; }
        //public List<News> articles { get; set; }


    }


