using aspnetserver.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Data
{
    internal static class RecordsRepository
    {
        internal async static Task<List<Record>> GetRecordsAsync()
        {
            using var db = new AppDbContext();
            return await db.Records.ToListAsync();
        }

        internal async static Task<Record> GetRecordByIdAsync(int recordId)
        {
            using var db = new AppDbContext();
            return await db.Records
                .FirstOrDefaultAsync(record => record.RecordId == recordId);
        }

        internal async static Task<bool> CreateRecordAsync(Record record)
        {
            using var db = new AppDbContext();
            try
            {
                await db.Records.AddAsync(record);
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
                db.Records.Update(record);
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
