using System;
namespace CryptoCrashLogic
{
    public class CryptCurrency
    {
        public string Asset_id_quote { get; set; }
        public double Asset_id_base { get; set; }
        public SrcData Src_side_quote { get; set; }
    }

    public class SrcData
    {
        public string Asset { get; set; }
        public double Rate { get; set; }
        public double Volume { get; set; }
    }
}

