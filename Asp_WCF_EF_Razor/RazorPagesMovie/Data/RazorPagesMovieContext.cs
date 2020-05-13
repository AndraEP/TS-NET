using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.PostDTO> PostDTO { get; set; }

        public DbSet<RazorPagesMovie.Models.CommentDTO> CommentDTO { get; set; }

        public DbSet<ServiceReferencePostComment.Post> Post { get; set; }
    }
}
