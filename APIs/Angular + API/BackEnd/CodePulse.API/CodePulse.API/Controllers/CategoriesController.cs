using CodePulse.API.Data;
using CodePulse.API.DTOs.CategoryDTO;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly ApplicationDbContext _db;

        public CategoriesController(ICategoryRepository categoryRepository, ApplicationDbContext db)
        {
            _categoryRepository = categoryRepository;
            _db = db;
        }


        //Post: 
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CategoryRquestDTO request)
        {
            var newCategory = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await _categoryRepository.CreateCategory(newCategory);



            var response = new CategoryDTO
            {
                Id = newCategory.Id,
                Name = newCategory.Name,
                UrlHandle = newCategory.UrlHandle,
            };


            return Ok(response);
        }



        //Get: https://localhost:7068/api/Categories/GetAllCategories
        [HttpGet("GetAllCategories")]
        public async Task <IActionResult> GetAllCategories()
        {

          var result = await _categoryRepository.GetAllCategories();

            if (!result.Any())
            {
                return NotFound("No Categories Found");
            }


            var responseList = result.Select(category => new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            }).ToList();


            return Ok(responseList);
        }

        //Get by Id: https://localhost:7068/api/Categories/id

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSingleCategory([FromRoute] Guid id)
        {

            var category = await _categoryRepository.GetCategoryById(id);

            if (category is null)
            {
                return NotFound($"No Category with id {id} found");
            }

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);

        }

        //Put: 
        [HttpPut("UpdateCategory/{id:Guid}")]
        public async Task <IActionResult> UpdateCategory(CategoryRquestDTO request, Guid id)
        {

            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            category = await _categoryRepository.UpdateCategory(category);

            if(category is null)
            {
                return NotFound("Category not Found");
            }

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

          return Ok(response);

        }

        [HttpDelete("DeleteCategory/{id:Guid}")]
        public async Task <IActionResult> DeleteCategory(Guid id)
        {
            var existingCategory = await _categoryRepository.DeleteCategory(id);

            if(existingCategory is null)
            {
                return NotFound("No Category Found");
            }

            var response = new CategoryDTO
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle,
            };

            return Ok(new
            {
                response = response,
                msg = "Category Deleted"

            });
        }
    }
}