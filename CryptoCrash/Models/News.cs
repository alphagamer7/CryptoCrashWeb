using System.ComponentModel.DataAnnotations;
using CryptoCrash.Areas.Identity.Data;
namespace CryptoCrash.Models
{
    public class News
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string urlToImage { get; set; }

        public string PublishedAt { get; set; }


        [Key]
        public ApplicationUser? User { get; set; }
    }
    
}
