using System;
namespace CryptoCrashLogic.Services
{
    public interface IWebClientService
    {
        Task<string> GetAsync(string uri);
        Task<string> PostAsync(string uri, string body, string type);
        Task<string> PutAsync(string uri, string body, string type);
    }
}

