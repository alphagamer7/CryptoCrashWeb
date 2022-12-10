using System.ComponentModel.DataAnnotations;
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
        public string Asset_id_quote { get; set; }
        public double Asset_id_base { get; set; }
        public SrcData Src_side_quote { get; set; }
    }

    public class SrcData
    {
        [Key]
        public int Id { get; set; }

        public string Asset { get; set; }
        public double Rate { get; set; }
        public double Volume { get; set; }
    }

}
