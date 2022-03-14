using aspnetserver.Data;
using aspnetserver.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Repositories
{
    internal static class UserRepository
    {
        internal async static Task<List<User>> GetUsersAsync()
        {
            using var db = new AppDbContext();
            return await db.User.ToListAsync();
        }

        internal async static Task<User> GetUserByIdAsync(int userId)
        {
            using var db = new AppDbContext();
            return await db.User
                .FirstOrDefaultAsync(user => user.Id == userId);
        }

        internal async static Task<bool> CreateUserAsync(User user)
        {
            using var db = new AppDbContext();
            try
            {
                await db.User.AddAsync(user);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateUserAsync(User user)
        {
            using var db = new AppDbContext();
            try
            {
                db.User.Update(user);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteUserAsync(int userId)
        {
            using var db = new AppDbContext();
            try
            {
                var user = await GetUserByIdAsync(userId);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
