using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CryptoCrashLogic.Model
{
    public class CryptCurrency
    {
        [Key]
        public string asset_id { get; set; }

        [Required]
        public int type_is_crypto { get; set; }

        [Required]
        public string id_icon { get; set; }

        [Required]
        public string name { get; set; }

        [AllowNull]
        public double price_usd { get; set; }

    }

}

