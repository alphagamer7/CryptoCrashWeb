using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCrash.Models;
using CryptoCrashLogic;
using Microsoft.AspNetCore.Identity;
using CryptoCurrency = CryptoCrash.Models.CryptoCurrency;
using News = CryptoCrash.Models.News;

namespace CryptoCrash.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ICollection<News>? ReadLaterList { get; set; }

    public ICollection<CryptoCurrency>? FavCryptoList { get; set; }

}

