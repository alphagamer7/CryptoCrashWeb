using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CryptoCrashLogic.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<News>? ReadLaterList { get; set; }

        public ICollection<CryptCurrency>? FavCryptoList { get; set; }
    }
}
