using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CryptoCrash.Areas.Identity.Data;
namespace CryptoCrash.Models
{
    public class CryptoCurrency
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string urlToImage { get; set; }
        public string url { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }

        [Key]
        public ApplicationUser? User { get; set; }
    }


    public class CryptCurrency
    {
        [Key]
        public string asset_id { get; set; }

        public int type_is_crypto { get; set; }

        public string id_icon { get; set; }
        public string name { get; set; }

        [AllowNull]
        public double price_usd { get; set; }

    }

}
