using aspnetserver.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class CardsRepository
    {
        internal async static Task<List<Card>> GetCardsAsync()
        {
            using var db = new AppDbContext();
            return await db.Cards.ToListAsync();
        }

        internal async static Task<Card> GetCardByIdAsync(int cardId)
        {
            using var db = new AppDbContext();
            return await db.Cards
                .FirstOrDefaultAsync(card => card.CardId == cardId);
        }

        internal async static Task<bool> CreateCardAsync(Card card)
        {
            using var db = new AppDbContext();
            try
            {
                await db.Cards.AddAsync(card);
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
                db.Cards.Update(card);
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
    }
}
