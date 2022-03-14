using aspnetserver.Data;
using aspnetserver.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Repositories
{
    internal static class CardRepository
    {
        internal async static Task<List<string>> GetCardNamesThatBeginWith(string namePart)
        {
            return await new AppDbContext().Card
                .TakeWhile(c => c.Name.StartsWith(namePart))
                .DistinctBy(c => c.Name)
                .Select(c => c.Name)
                .ToListAsync();
        }

        internal async static Task<List<Card>> GetCardsWithName(string name)
        {
            return await new AppDbContext().Card
                .TakeWhile(c => c.Name.Equals(name))
                .ToListAsync();
        }

        internal async static Task<List<Card>> GetCardsAsync()
        {
            using var db = new AppDbContext();
            return await db.Card.ToListAsync();
        }

        internal async static Task<Card> GetCardByIdAsync(int cardId)
        {
            using var db = new AppDbContext();
            return await db.Card
                .FirstOrDefaultAsync(card => card.Id == cardId);
        }

        internal async static Task<bool> CreateCardAsync(Card card)
        {
            using var db = new AppDbContext();
            try
            {
                await db.Card.AddAsync(card);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateCardAsync(Card card)
        {
            using var db = new AppDbContext();
            try
            {
                db.Card.Update(card);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteCardAsync(int cardId)
        {
            using var db = new AppDbContext();
            try
            {
                var card = await GetCardByIdAsync(cardId);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<int> InsertCardsAsync(Models.Data data)
        {
            if (data == null) throw new Exception("CardRepository: InsertCardsAsync => data is null");

            using var db = new AppDbContext();

            await db.Card.AddRangeAsync(data.Cards);

            return await db.SaveChangesAsync();
        }
    }
}
