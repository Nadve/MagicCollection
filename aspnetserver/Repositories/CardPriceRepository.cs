using aspnetserver.Data;

namespace aspnetserver.Repositories
{
    internal static class CardPriceRepository
    {
        internal static async Task<int> InsertPrices(Models.Data data)
        {
            using var db = new AppDbContext();
            Task.WaitAll(new Task[]
            {
                db.CardPriceEur.AddRangeAsync(data.CardPricesEur),
                db.CardPriceEurFoil.AddRangeAsync(data.CardPricesEurFoil),
                db.CardPriceUsd.AddRangeAsync(data.CardPricesUsd),
                db.CardPriceUsd.AddRangeAsync(data.CardPricesUsd),
                db.CardPriceUsdFoil.AddRangeAsync(data.CardPricesUsdFoil),
                db.CardPriceUsdEtched.AddRangeAsync(data.CardPricesUsdEtched),
                db.CardPriceUsdGlossy.AddRangeAsync(data.CardPricesUsdGlossy)
            });

            return await db.SaveChangesAsync();
        }
    }
}
