using Microsoft.EntityFrameworkCore;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("f61d66c1-13a1-4d7a-96c9-2d309939af55"),
                    Name = "Khó"
                },
                   new Difficulty
                {
                    Id = Guid.Parse("b2a19d46-0439-41fd-bbb4-93b01a226ebf"),
                    Name = "Vừa"
                },
                      new Difficulty
                {
                    Id = Guid.Parse("4fdeccb7-8506-4621-881c-c10427072064"),
                    Name = "Dễ"
                },
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>
            {
                  new Region
                  {
                           Id = Guid.Parse("ededd4e3-e398-4a91-95fe-d610151bd1f1"),
                           Name = "Hà Nội",
                           Code = "HN",
                           RegionImageUrl = null
                  },
                   new Region
                  {
                           Id = Guid.Parse("e5e666ca-cd5e-4fc7-8c72-9907ee3d6323"),
                           Name = "Thanh Hóa",
                           Code = "TH",
                           RegionImageUrl = null
                  },
                    new Region
                  {
                           Id = Guid.Parse("43e22194-6b1e-4622-bf01-8de512e090af"),
                           Name = "Quảng Ninh",
                           Code = "QN",
                           RegionImageUrl = null
                  },
                     new Region
                  {
                           Id = Guid.Parse("9d831acd-7bcb-44f5-a363-2940ab912c2a"),
                           Name = "Đà Nẵng",
                           Code = "DN",
                           RegionImageUrl = null
                  },
                    new Region
                  {
                           Id = Guid.Parse("05011613-2824-4e4b-ae26-f2c204220a6d"),
                           Name = "Hội An",
                           Code = "HA",
                           RegionImageUrl = null
                  }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
