using CryptoCrash.Areas.Identity.Data;
using CryptoCrash.Models;
using CryptoCrashLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCrash.Controllers
{
    public class CryptoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private List<CryptoCurrency> cryptoList = new List<CryptoCurrency>();

        private bool hasError = false;
        private readonly CryptoApiClient<CryptoCurrency> _cryptoApiClient;

        public CryptoController(ApplicationDbContext context, CryptoApiClient<CryptoCurrency> cryptoApiClient)
        {
            _context = context;
            _cryptoApiClient = cryptoApiClient;

            try
            {
                var response = _cryptoApiClient.GetCryptoList();
                cryptoList = response.Result.Take(10).ToList();
                Console.Write(cryptoList);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                hasError = true;
            }
        }

        private ApplicationUser? GetUser()
        {
            var username = User.Identity!.Name;
            return (from u in _context.Users
                    where string.Equals(username, u.UserName)
                    select u)
                .FirstOrDefault();
        }

        public ActionResult Index()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            TempData["Error"] = hasError;
            if (hasError)
                return View();
            return View(cryptoList);
        }


        public ActionResult CryptoList()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return Redirect("~/Identity/Account/Login");
            }
            TempData["Error"] = hasError;
            if (hasError)
                return View();
            return View(cryptoList);
        }
    }
}
