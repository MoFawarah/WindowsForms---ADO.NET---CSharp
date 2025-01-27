using Azure;
using CodePulse.API.DTOs.BlogPostDTO;
using CodePulse.API.DTOs.CategoryDTO;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BlogPostsController(IBlogPostRepository blogPostRepository, ICategoryRepository categoryRepository)
        {
            _blogPostRepository = blogPostRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost("CreateBlogPost")]
        public async Task <IActionResult> CreateBlogPost(BlogPostRequestDTO request)
        {

            //map dto to the domain model (convert dto to domain so we can send it to the repository)
            var blogPost = new BlogPost
            {
                Title = request.Title,
                ShortDescription = request.ShortDescription,
                Content = request.Content,
                FeaturedImageUrl = request.FeaturedImageUrl,
                UrlHandle = request.UrlHandle,
                PublishedDate = request.PublishedDate,
                Author = request.Author,
                IsVisible = request.IsVisible,
                Categories = new List<Category>()

            };

            foreach (var categoryGuidID in request.CategoriesID)
            {
                var existingCategory = await _categoryRepository.GetCategoryById(categoryGuidID);

                if(existingCategory is not null)
                {
                   blogPost.Categories.Add(existingCategory);
                }
                else
                {
                    return BadRequest("The Category ID is not correct");
                }
            }

           blogPost = await _blogPostRepository.createBlogPost(blogPost);

            // Convert Domian Model Back to DTO

            var response = new BlogPostResponseDTO
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                ShortDescription = blogPost.ShortDescription,
                Content = blogPost.Content,
                FeaturedImageUrl = blogPost.FeaturedImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                IsVisible = blogPost.IsVisible,
                Categories = blogPost.Categories.Select(c => new CategoryDTO
                {
                    Id= c.Id,
                    Name = c.Name,  
                    UrlHandle= c.UrlHandle,
                }).ToList() 

            };

           return Ok(response);


        }

        [HttpGet("GetAllBlogPosts")]
        public async Task  <IActionResult> GetAllBlogPosts()
        {

            var blogPosts = await _blogPostRepository.getBlogPosts();

            if (blogPosts == null)
            {
                return NotFound("No Blog Posts Found");
            }

            var response = new List<BlogPostResponseDTO>();


            foreach (var blogPost in blogPosts)
            {
                response.Add(new BlogPostResponseDTO
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    ShortDescription = blogPost.ShortDescription,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    PublishedDate = blogPost.PublishedDate,
                    Author = blogPost.Author,
                    IsVisible = blogPost.IsVisible,

                    Categories = blogPost.Categories.Select(c => new CategoryDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        UrlHandle = c.UrlHandle,
                    }).ToList()
                });
            }

            

            return Ok(response);
        }
    }
}
