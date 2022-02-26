using DownloadCards.Models;
using DownloadCards.Models.Finishes;
using DownloadCards.Models.Images;
using DownloadCards.Models.Prices.Cards;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DownloadCards
{

    class Program
    {
        private static readonly HttpClient client = new();
        private static readonly string fileName = $"{Environment.CurrentDirectory}\\{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}.json";
        private const string Seed = "922022.json";

        static async Task Main()
        {
            await Download();
            await Deserialize();
        }

        private static async Task<Data> Deserialize()
        {
            IList<CardJson> allCards = null;
            int cardId, priceEurId, priceEurFoilId, priceUsdId, priceUsdFoilId, priceUsdEtchedId, priceUsdGlossyId, foilId, etchedId, glossyId, frontFaceId, backFaceId;
            cardId = priceEurId = priceEurFoilId = priceUsdId = priceUsdFoilId = priceUsdEtchedId = priceUsdGlossyId = foilId = etchedId = glossyId = frontFaceId = backFaceId = 0;
            var data = new Data();
            try
            {
                allCards = await JsonSerializer.DeserializeAsync<IList<CardJson>>(File.OpenRead(Seed));
            }
            catch (Exception e)
            {
                var file = File.CreateText("log.txt");
                file.WriteLine(e.ToString());
            }
            if (allCards == null)
                return null;

            foreach (var card in allCards)
            {
                if (card.ImageStatus.Equals("missing"))
                    continue;

                cardId += 1;
                data.Cards.Add(new Card
                {
                    CardId = cardId,
                    Name = card.Name,
                    Set = card.Set,
                    CollectorNumber = card.CollectorNumber,
                });

                frontFaceId += 1;
                if (card.ImageUri != null)
                {
                    data.FrontFaces.Add(new FrontFace
                    {
                        ImageId = frontFaceId,
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
                        ImageId = frontFaceId,
                        CardId = cardId,
                        UriLarge = card.CardFaces[0].ImageUri.Large,
                        UriNormal = card.CardFaces[0].ImageUri.Normal,
                        UriSmall = card.CardFaces[0].ImageUri.Small
                    });
                    data.BackFaces.Add(new BackFace
                    {
                        ImageId = backFaceId,
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
                            data.FoilFinishes.Add(new FoilFinish
                            {
                                CardId = cardId,
                                FinishId = foilId
                            }); break;
                        case "etched":
                            etchedId += 1;
                            data.EtchedFinishes.Add(new EtchedFinish
                            {
                                CardId = cardId,
                                FinishId = etchedId
                            }); break;
                        case "glossy":
                            glossyId += 1;
                            data.GlossyFinishes.Add(new GlossyFinish
                            {
                                CardId = cardId,
                                FinishId = glossyId
                            }); break;
                    }
                }

                if (card.Price.Eur != null)
                {
                    priceEurId += 1;
                    data.CardPricesEur.Add(new CardPriceEur
                    {
                        CardId = cardId,
                        PriceId = priceEurId,
                        Price = double.Parse(card.Price.Eur, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.EurFoil != null)
                {
                    priceEurFoilId += 1;
                    data.CardPricesEurFoil.Add(new CardPriceEurFoil
                    {
                        CardId = cardId,
                        PriceId = priceEurFoilId,
                        Price = double.Parse(card.Price.EurFoil, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.Usd != null)
                {
                    priceUsdId += 1;
                    data.CardPricesUsd.Add(new CardPriceUsd
                    {
                        CardId = cardId,
                        PriceId = priceUsdId,
                        Price = double.Parse(card.Price.Usd, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdFoil != null)
                {
                    priceUsdFoilId += 1;
                    data.CardPricesUsdFoil.Add(new CardPriceUsdFoil
                    {
                        CardId = cardId,
                        PriceId = priceUsdFoilId,
                        Price = double.Parse(card.Price.UsdFoil, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdEtched != null)
                {
                    priceUsdEtchedId += 1;
                    data.CardPricesUsdEtched.Add(new CardPriceUsdEtched
                    {
                        CardId = cardId,
                        PriceId = priceUsdEtchedId,
                        Price = double.Parse(card.Price.UsdEtched, CultureInfo.InvariantCulture)
                    });
                }

                if (card.Price.UsdGlossy != null)
                {
                    priceUsdGlossyId += 1;
                    data.CardPricesUsdGlossy.Add(new CardPriceUsdGlossy
                    {
                        CardId = cardId,
                        PriceId = priceUsdGlossyId,
                        Price = double.Parse(card.Price.UsdGlossy, CultureInfo.InvariantCulture)
                    });
                }
            }
            return data;
        }

        /// <summary>
        /// Sometimes fails to downlaod all the cards
        /// </summary>
        private static async Task Download()
        {
            if (File.Exists(fileName)) { 
                Console.WriteLine($"{fileName} was already found. Download skipped");
                return;
            }

            try
            {
                var streamTask = client.GetStreamAsync("https://api.scryfall.com/bulk-data");
                var bulk = await JsonSerializer.DeserializeAsync<BulkFiles>(await streamTask);
                var cardStream = await client.GetStreamAsync(bulk.GetDownloadUrl());
                using var fileStream = File.Create(fileName);
                cardStream.CopyTo(fileStream);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Download done");
        }
    }
}
