using System;

namespace CryptoCrashLogic.Models
{
    public class CryptCurrency
    {
        public string asset_id { get; set; }

        public int type_is_crypto { get; set; }

        public string id_icon { get; set; }
        public string name { get; set; }

        public double price_usd { get; set; }

    }

    public class SrcData
    {
        public string Asset { get; set; }
        public double Rate { get; set; }
        public double Volume { get; set; }
    }
}

