using aspnetserver.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class RecordRepository
    {
        internal async static Task<List<Record>> GetRecordAsync()
        {
            using var db = new AppDbContext();
            return await db.Record.ToListAsync();
        }

        internal async static Task<Record> GetRecordByIdAsync(int recordId)
        {
            using var db = new AppDbContext();
            return await db.Record
                .FirstOrDefaultAsync(record => record.Id == recordId);
        }

        internal async static Task<bool> CreateRecordAsync(Record record)
        {
            using var db = new AppDbContext();
            try
            {
                await db.Record.AddAsync(record);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateRecordAsync(Record record)
        {
            using var db = new AppDbContext();
            try
            {
                db.Record.Update(record);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteRecordAsync(int recordId)
        {
            using var db = new AppDbContext();
            try
            {
                var record = await GetRecordByIdAsync(recordId);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
