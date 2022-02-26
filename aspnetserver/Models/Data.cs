using aspnetserver.Models.Finishes;
using aspnetserver.Models.Prices.Cards;

namespace aspnetserver.Models
{
    internal class Data
    {
        public List<Card> Cards { get; set; }
        public List<CardPriceEur> CardPricesEur { get; set; }
        public List<CardPriceEurFoil> CardPricesEurFoil { get; set; }
        public List<CardPriceUsd> CardPricesUsd { get; set; }
        public List<CardPriceUsdFoil> CardPricesUsdFoil { get; set; }
        public List<CardPriceUsdEtched> CardPricesUsdEtched { get; set; }
        public List<CardPriceUsdGlossy> CardPricesUsdGlossy { get; set; }
        public List<FoilFinish> FoilFinishes { get; set; }
        public List<EtchedFinish> EtchedFinishes { get; set; }
        public List<GlossyFinish> GlossyFinishes { get; set; }
        public List<FrontFace> FrontFaces { get; set; }
        public List<BackFace> BackFaces { get; set; }

        public Data()
        {
            Cards = new List<Card>();
            CardPricesEur = new List<CardPriceEur>();
            CardPricesEurFoil = new List<CardPriceEurFoil>();
            CardPricesUsd = new List<CardPriceUsd>();
            CardPricesUsdFoil = new List<CardPriceUsdFoil>();
            CardPricesUsdEtched = new List<CardPriceUsdEtched>();
            CardPricesUsdGlossy = new List<CardPriceUsdGlossy>();
            FoilFinishes = new List<FoilFinish>();
            EtchedFinishes = new List<EtchedFinish>();
            GlossyFinishes = new List<GlossyFinish>();
            FrontFaces = new List<FrontFace>();
            BackFaces = new List<BackFace>();
        }
    }
}
