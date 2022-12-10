using System;
using static CryptoCrashLogic.Services.CryptoApiClient;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CryptoCrashLogic.Services
{
    public class NewsApiClient<T>
    {
        private readonly HttpClient client;
        private readonly string MOVIE_API_URL;
        private readonly string API_KEY;

        public NewsApiClient()
        {
            client = new();
        }

        private WebClientService clientService = new WebClientService();
        public static string newsUrl = 
            "https://newsapi.org/v2/everything?q=cryptocurrency&apiKey=D08d6b3c579542f0abbae1f6a3c3949a";


        public async Task<List<T>> GetNews()
        {


            HttpResponseMessage response = await client.GetAsync(newsUrl);
            
            var body =  response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null; // since sometimes api timeouts
   
            
                return CreateNewsFromJson(body);
        }

        public async Task<List<T>> GetNewsItems()
        {
            var json = await clientService.GetAsync(newsUrl);
            return CreateNewsFromJson(json);
        }

        public List<T> CreateNewsFromJson(string json)
        {
       
            var resVal = JsonConvert.DeserializeObject<NewsResponse>(json);
            Console.WriteLine(resVal.articles);
            var res = JsonConvert.DeserializeObject<Response<T>>(json);
            return res?.articles!;
        }

    }

    public class NewsResponse
    {
        public List<News> articles { get; set; }
        public string status { get; set; }
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


