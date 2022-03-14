using aspnetserver.Data;
using aspnetserver.Models.Finishes;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Repositories
{
    internal static class FinishRepository
    {
        internal async static Task<List<string>> GetFinishesByCardIdAsync(int cardId)
        {
            using var db = new AppDbContext();
            var foil = db.FoilFinish.FirstOrDefaultAsync(f => f.CardId == cardId);
            var etched = db.EtchedFinish.FirstOrDefaultAsync(f => f.CardId == cardId);       
            var glossy = db.GlossyFinish.FirstOrDefaultAsync(f => f.CardId == cardId);

            var finishes = new List<string>
            {
                "non-foil"
            };

            if (await foil != null)
            {
                finishes.Add("foil");
            }

            if (await etched != null)
            {
                finishes.Add("etched");
            }

            if (await glossy != null)
            {
                finishes.Add("glossy");
            }

            return finishes;
        }

        internal async static Task<int> SyncFinishes(Models.Data data)
        {
            if (data == null) throw new Exception("FinishRepository.SyncFinishes arg is null");

            var foilChanges = SyncFoilFinish(data.FoilFinishes);
            var etchedChanges = SyncEtchedFinish(data.EtchedFinishes); 
            var glossyChanges = SyncGlossyFinish(data.GlossyFinishes);

            return await foilChanges + await etchedChanges + await glossyChanges;
        }

        private async static Task<int> SyncFoilFinish(List<FoilFinish> finishes)
        {
            using var db = new AppDbContext();
            var foilFinish = db.FoilFinish.ToListAsync();
            var newFoilFinishes = finishes.Except(await foilFinish);
            if (newFoilFinishes.Any())
                return await InsertFoilFinishes(newFoilFinishes);

            return 0;
        }

        private async static Task<int> InsertFoilFinishes(IEnumerable<FoilFinish> finishes)
        {
            using var db = new AppDbContext();
            await db.FoilFinish.AddRangeAsync(finishes);

            return await db.SaveChangesAsync();
        }

        private async static Task<int> SyncEtchedFinish(List<EtchedFinish> finishes)
        {
            using var db = new AppDbContext();

            var etchedFinish = db.EtchedFinish.ToListAsync();
            var newEtchedFinishes = finishes.Except(await etchedFinish);
            if (newEtchedFinishes.Any())
                return await InsertEtchedFinishes(newEtchedFinishes);

            return 0;
        }

        private async static Task<int> InsertEtchedFinishes(IEnumerable<EtchedFinish> finishes)
        {
            using var db = new AppDbContext();
            await db.EtchedFinish.AddRangeAsync(finishes);

            return await db.SaveChangesAsync();
        }

        private async static Task<int> SyncGlossyFinish(List<GlossyFinish> finishes)
        {
            using var db = new AppDbContext();
            var glossyFinish = db.GlossyFinish.ToListAsync();
            var newGlossyFinishes = finishes.Except(await glossyFinish);
            if (newGlossyFinishes.Any())
                return await InsertGlossyFinishes(newGlossyFinishes);

            return 0;
        }

        private async static Task<int> InsertGlossyFinishes(IEnumerable<GlossyFinish> finishes)
        {
            using var db = new AppDbContext();
            await db.GlossyFinish.AddRangeAsync(finishes);

            return await db.SaveChangesAsync();
        }
    }
}
