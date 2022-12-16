using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptoCrashLogic.Services
{
    public class CryptoApiClient<T>
    {
        public static string cryptoUrl = "https://rest.coinapi.io/v1/assets?apikey=0DEB865A-360B-49B6-841C-811224CFCB2F&history?period_id=1DAY";
        public static string apiKey = "0DEB865A-360B-49B6-841C-811224CFCB2F";

        private readonly HttpClient client;

        public CryptoApiClient()
        {
            client = new();
        }


        public async Task<List<T>> GetCryptoList()
        {
            HttpResponseMessage response = await client.GetAsync(cryptoUrl);
            var body = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null; // since sometimes api timeouts
            return CreateCryptoListFromJson(body);
        }

        public List<T> CreateCryptoListFromJson(string json) => JsonConvert.DeserializeObject<List<T>>(json);

    }
}

