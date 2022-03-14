using aspnetserver.Models.Finishes;
using aspnetserver.Models.Images;
using aspnetserver.Models.Prices.Cards;
using aspnetserver.Scryfall;
using System.Globalization;
using System.Text.Json;

namespace aspnetserver.Models
{
    internal static class JsonDeserializer
    {
        private static readonly string Seed = @"D:\ScryfallJsons\922022.json";

        public static Data? Deserialize()
        {
            IList<CardJson>? allCards = null;
            int cardId, priceEurId, priceEurFoilId, priceUsdId, priceUsdFoilId, priceUsdEtchedId, priceUsdGlossyId, foilId, etchedId, glossyId, frontFaceId, backFaceId;
            cardId = priceEurId = priceEurFoilId = priceUsdId = priceUsdFoilId = priceUsdEtchedId = priceUsdGlossyId = foilId = etchedId = glossyId = frontFaceId = backFaceId = 0;
            var data = new Data();
            allCards = JsonSerializer.Deserialize<IList<CardJson>>(File.OpenRead(Seed));
            if (allCards == null)
                return null;

            foreach (var card in allCards)
            {
                if (card.ImageStatus.Equals("missing"))
                    continue;

                cardId += 1;
                data.Cards.Add(new Card
                {
                    Id = cardId,
                    Name = card.Name,
                    Set = card.Set,
                    CollectorNumber = card.CollectorNumber,
                });

                frontFaceId += 1;
                if (card.ImageUri != null)
                {
                    data.FrontFaces.Add(new FrontFace
                    {
                        Id = frontFaceId,
                        CardId = cardId,
                        UriLarge = card.ImageUri.Large,
                        UriNormal = card.ImageUri.Normal,
                        UriSmall = card.ImageUri.Small
                    });
                }
                else
                {
                    backFaceId += 1;
                    data.FrontFaces.Add(new FrontFace
                    {
                        Id = frontFaceId,
                        CardId = cardId,
                        UriLarge = card.CardFaces[0].ImageUri.Large,
                        UriNormal = card.CardFaces[0].ImageUri.Normal,
                        UriSmall = card.CardFaces[0].ImageUri.Small
                    });
                    data.BackFaces.Add(new BackFace
                    {
                        Id = backFaceId,
                        CardId = cardId,
                        UriLarge = card.CardFaces[1].ImageUri.Large,
                        UriNormal = card.CardFaces[1].ImageUri.Normal,
                        UriSmall = card.CardFaces[1].ImageUri.Small
                    });
                }

                foreach (var finish in card.Finishes)
                {
                    switch (finish)
                    {
                        case "foil":
                            foilId += 1;
                            data.FoilFinishes.Add(new FoilFinish{ CardId = cardId, Id = foilId });
                            break;
                        case "etched":
                            etchedId += 1;
                            data.EtchedFinishes.Add(new EtchedFinish{ CardId = cardId, Id = etchedId });
                            break;
                        case "glossy":
                            glossyId += 1;
                            data.GlossyFinishes.Add(new GlossyFinish{ CardId = cardId, Id = glossyId });
                            break;
                    }
                }

                if (card.Price.Eur != null)
                {
                    priceEurId += 1;
                    data.CardPricesEur.Add(new CardPriceEur
                    {
                        CardId = cardId,
                        Id = priceEurId,
                        Price = double.Parse(card.Price.Eur, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.EurFoil != null)
                {
                    priceEurFoilId += 1;
                    data.CardPricesEurFoil.Add(new CardPriceEurFoil
                    {
                        CardId = cardId,
                        Id = priceEurFoilId,
                        Price = double.Parse(card.Price.EurFoil, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.Usd != null)
                {
                    priceUsdId += 1;
                    data.CardPricesUsd.Add(new CardPriceUsd
                    {
                        CardId = cardId,
                        Id = priceUsdId,
                        Price = double.Parse(card.Price.Usd, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdFoil != null)
                {
                    priceUsdFoilId += 1;
                    data.CardPricesUsdFoil.Add(new CardPriceUsdFoil
                    {
                        CardId = cardId,
                        Id = priceUsdFoilId,
                        Price = double.Parse(card.Price.UsdFoil, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdEtched != null)
                {
                    priceUsdEtchedId += 1;
                    data.CardPricesUsdEtched.Add(new CardPriceUsdEtched
                    {
                        CardId = cardId,
                        Id = priceUsdEtchedId,
                        Price = double.Parse(card.Price.UsdEtched, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdGlossy != null)
                {
                    priceUsdGlossyId += 1;
                    data.CardPricesUsdGlossy.Add(new CardPriceUsdGlossy
                    {
                        CardId = cardId,
                        Id = priceUsdGlossyId,
                        Price = double.Parse(card.Price.UsdGlossy, CultureInfo.InvariantCulture)
                    });
                }
            }
            return data;
        }
    }
}
