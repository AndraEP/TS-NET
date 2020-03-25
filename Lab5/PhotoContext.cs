using System.Data.Entity;

namespace Lab4
{
    class PhotoContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotographFullImage> PhotoFulls { get; set; }
        public PhotoContext() : base("name=ModelSelfReferences") 
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Photo>()
            .HasRequired(p => p.PhotographFullImage)
            .WithRequiredPrincipal(p => p.Photograph);

            modelBuilder.Entity<Photo>()
            .ToTable("Photograph", "BazaDeDate");

            modelBuilder.Entity<PhotographFullImage>()
            .ToTable("Photograph", "BazaDeDate");
        }

    }
}
