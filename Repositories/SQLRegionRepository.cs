using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var exitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(exitingRegion);
            await dbContext.SaveChangesAsync();

            return exitingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var exitingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (exitingRegion == null)
            {
                return null;
            }

            exitingRegion.Code = region.Code;
            exitingRegion.Name = region.Name;
            exitingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return exitingRegion;
        }
    }
}
