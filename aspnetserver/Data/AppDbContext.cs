using aspnetserver.Models;
using aspnetserver.Models.Finishes;
using aspnetserver.Models.Images;
using aspnetserver.Models.Prices.Cards;
using aspnetserver.Models.Prices.Records;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal sealed class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<FoilFinish> FoilFinish { get; set; }
        public DbSet<EtchedFinish> EtchedFinish { get; set; }
        public DbSet<GlossyFinish> GlossyFinish { get; set; }
        public DbSet<CardPriceEur> CardPriceEur { get; set; }
        public DbSet<CardPriceEurFoil> CardPriceEurFoil { get; set; }
        public DbSet<CardPriceUsd> CardPriceUsd { get; set; }
        public DbSet<CardPriceUsdFoil> CardPriceUsdFoil { get; set; }
        public DbSet<CardPriceUsdEtched> CardPriceUsdEtched { get; set; }
        public DbSet<CardPriceUsdGlossy> CardPriceUsdGlossy { get; set; }
        public DbSet<RecordPriceEur> RecordPriceEur { get; set; }
        public DbSet<RecordPriceEur> RecordPriceEurFoil { get; set; }
        public DbSet<RecordPriceEur> RecordPriceUsd { get; set; }
        public DbSet<RecordPriceEur> RecordPriceUsdFoil { get; set; }
        public DbSet<RecordPriceEur> RecordPriceUsdGlossy { get; set; }
        public DbSet<RecordPriceEur> RecordPriceUsdEtched { get; set; }
        public DbSet<FrontFace> CardFrontFace { get; set; }
        public DbSet<BackFace> CardBackFace { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.EnableSensitiveDataLogging();
            dbContextOptionsBuilder.UseSqlite("Data Source=./Data/AppDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "admin",
                Password = "admin",
            });

            //var data = Deserialize();
            //if (data == null)
            //    throw new Exception("Deserialization failed");

            //modelBuilder.Entity<Card>().HasData(data.Cards);
            //modelBuilder.Entity<CardPriceEur>().HasData(data.CardPricesEur);
            //modelBuilder.Entity<CardPriceEurFoil>().HasData(data.CardPricesEurFoil);
            //modelBuilder.Entity<CardPriceUsd>().HasData(data.CardPricesUsd);
            //modelBuilder.Entity<CardPriceUsdFoil>().HasData(data.CardPricesUsdFoil);
            //modelBuilder.Entity<CardPriceUsdEtched>().HasData(data.CardPricesUsdEtched);
            //modelBuilder.Entity<CardPriceUsdGlossy>().HasData(data.CardPricesUsdGlossy);
            //modelBuilder.Entity<FoilFinish>().HasData(data.FoilFinishes);
            //modelBuilder.Entity<EtchedFinish>().HasData(data.EtchedFinishes);
            //modelBuilder.Entity<GlossyFinish>().HasData(data.GlossyFinishes);
            //modelBuilder.Entity<FrontFace>().HasData(data.FrontFaces);
            //modelBuilder.Entity<BackFace>().HasData(data.BackFaces);
        }
    }
}
