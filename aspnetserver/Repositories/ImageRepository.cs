using aspnetserver.Data;
using aspnetserver.Models.Images;
using Microsoft.EntityFrameworkCore;

namespace aspnetserver.Repositories
{
    internal static class ImageRepository
    {
        internal static async Task<string> GetLargeImageByCardIdAsync(int cardId)
        {
            using var db = new AppDbContext();

            var image = await db.CardFrontFace.FirstOrDefaultAsync(i => i.CardId == cardId);

            if (image == null)
                throw new Exception("ImageRepository.GetLargeImageByCardIdAsync: image is null");

            return image.UriLarge;
        }

        internal static async Task<int> SyncImages(Models.Data data)
        {
            if (data == null) throw new Exception("ImageRepository.SyncImages arg is null");


            var frontFaceChanges = SyncFrontFace(data.FrontFaces);
            var backFaceChanges = SyncBackFace(data.BackFaces);

            return await frontFaceChanges + await backFaceChanges;
        }

        private static async Task<int> SyncFrontFace(List<FrontFace> images)
        {
            using var db = new AppDbContext();
            var frontFaces = db.CardFrontFace.ToListAsync();
            var newFrontFaces = images.Except(await frontFaces);
            if (newFrontFaces.Any())
                return await InsertFrontFaces(newFrontFaces);

            return 0;
        }

        private static async Task<int> InsertFrontFaces(IEnumerable<FrontFace> images)
        {
            using var db = new AppDbContext();
            await db.CardFrontFace.AddRangeAsync(images);

            return await db.SaveChangesAsync();
        }

        private static async Task<int> SyncBackFace(List<BackFace> images)
        {
            using var db = new AppDbContext();
            var backFaces = db.CardBackFace.ToListAsync();
            var newBackFaces = images.Except(await backFaces);
            if (newBackFaces.Any())
                return await InsertBackFaces(newBackFaces);

            return 0;
        }

        private static async Task<int> InsertBackFaces(IEnumerable<BackFace> images)
        {
            using var db = new AppDbContext();
            await db.CardBackFace.AddRangeAsync(images);

            return await db.SaveChangesAsync();
        }
    }
}
