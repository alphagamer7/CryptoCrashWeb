using System.ComponentModel.DataAnnotations;
using CryptoCrash.Areas.Identity.Data;
namespace CryptoCrash.Models
{
    public class News
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string urlToImage { get; set; }

        [Required]
        public string PublishedAt { get; set; }


        [Key]
        public ApplicationUser? User { get; set; }
    }
    
}
