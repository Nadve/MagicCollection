using aspnetserver.Models;
using aspnetserver.Models.Finishes;
using aspnetserver.Models.Prices.Cards;
using aspnetserver.Models.Prices.Records;
using aspnetserver.Scryfall;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.Json;

namespace aspnetserver.Data
{
    internal sealed class AppDbContext : DbContext
    {
        private static readonly string Seed = "922022.json";
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<FoilFinish> FoilFinishes { get; set; }
        public DbSet<EtchedFinish> EtchedFinishes { get; set; }
        public DbSet<GlossyFinish> GlossyFinishes { get; set; }
        public DbSet<CardPriceEur> CardPricesEur { get; set; }
        public DbSet<CardPriceEurFoil> CardPricesEurFoil { get; set; }
        public DbSet<CardPriceUsd> CardPricesUsd { get; set; }
        public DbSet<CardPriceUsdFoil> CardPricesUsdFoil { get; set; }
        public DbSet<CardPriceUsdEtched> CardPricesUsdEtched { get; set; }
        public DbSet<CardPriceUsdGlossy> CardPricesUsdGlossy { get; set; }
        public DbSet<FrontFace> CardFrontFaces { get; set; }
        public DbSet<BackFace> CardBackFaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.Cards)
                        .WithOne(p => p.User)
                        .HasForeignKey(p => p.CardId);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasMany(e => e.Possessions)
                      .WithOne(p => p.Card)
                      .HasForeignKey(p => p.CardId);
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasOne(r => r.Card)
                      .WithMany(c => c.Records)
                      .HasForeignKey(r => r.CardId);
            });

            modelBuilder.Entity<FoilFinish>(entity =>
            {
                entity.HasKey(e => e.FinishId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<EtchedFinish>(entity =>
            {
                entity.HasKey(e => e.FinishId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<GlossyFinish>(entity =>
            {
                entity.HasKey(e => e.FinishId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceEur>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceEurFoil>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceUsd>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceUsdFoil>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceUsdEtched>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<CardPriceUsdGlossy>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<RecordPriceEur>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<RecordPriceEurFoil>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<RecordPriceUsd>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<RecordPriceUsdFoil>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<RecordPriceUsdEtched>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<RecordPriceUsdGlossy>(entity =>
            {
                entity.HasKey(e => e.PriceId);
                entity.HasOne(e => e.Record);
            });

            modelBuilder.Entity<FrontFace>(entity =>
            {
                entity.HasKey(e => e.ImageId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<BackFace>(entity =>
            {
                entity.HasKey(e => e.ImageId);
                entity.HasOne(e => e.Card);
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "admin",
                Password = "admin",
            });

            var data = Deserialize();
            if (data == null)
                throw new Exception("Deserialization failed");

            modelBuilder.Entity<Card>().HasData(data.Cards);
            modelBuilder.Entity<CardPriceEur>().HasData(data.CardPricesEur);
            modelBuilder.Entity<CardPriceEurFoil>().HasData(data.CardPricesEurFoil);
            modelBuilder.Entity<CardPriceUsd>().HasData(data.CardPricesUsd);
            modelBuilder.Entity<CardPriceUsdFoil>().HasData(data.CardPricesUsdFoil);
            modelBuilder.Entity<CardPriceUsdEtched>().HasData(data.CardPricesUsdEtched);
            modelBuilder.Entity<CardPriceUsdGlossy>().HasData(data.CardPricesUsdGlossy);
            modelBuilder.Entity<FoilFinish>().HasData(data.FoilFinishes);
            modelBuilder.Entity<EtchedFinish>().HasData(data.EtchedFinishes);
            modelBuilder.Entity<GlossyFinish>().HasData(data.GlossyFinishes);
            modelBuilder.Entity<FrontFace>().HasData(data.FrontFaces);
            modelBuilder.Entity<BackFace>().HasData(data.BackFaces);
        }

        private static Models.Data? Deserialize()
        {
            IList<CardJson>? allCards = null;
            int cardId, priceEurId, priceEurFoilId, priceUsdId, priceUsdFoilId, priceUsdEtchedId, priceUsdGlossyId, foilId, etchedId, glossyId, frontFaceId, backFaceId;
            cardId = priceEurId = priceEurFoilId = priceUsdId = priceUsdFoilId = priceUsdEtchedId = priceUsdGlossyId = foilId = etchedId = glossyId = frontFaceId = backFaceId = 0;
            var data = new Models.Data();
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

    }
}
