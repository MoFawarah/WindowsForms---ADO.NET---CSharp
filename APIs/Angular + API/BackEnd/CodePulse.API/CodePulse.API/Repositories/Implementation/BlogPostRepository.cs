using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _db;
        public BlogPostRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<BlogPost> createBlogPost(BlogPost blogPost)
        {
            await _db.BlogPosts.AddAsync(blogPost);
            await _db.SaveChangesAsync();

            return blogPost;    
        }

        public async Task<IEnumerable<BlogPost>> getBlogPosts()
        {
            var blogPosts = await _db.BlogPosts.Include(blogPost => blogPost.Categories ).ToListAsync();

            return blogPosts;
         
        }
    }
}
