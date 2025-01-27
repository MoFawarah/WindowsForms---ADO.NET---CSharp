using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateCategory(Category newCategory)
        {
            await _db.Categories.AddAsync(newCategory);
            await _db.SaveChangesAsync();

            return newCategory;
        }

        public async Task<Category?> DeleteCategory(Guid id)
        {
            var exisitingCategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (exisitingCategory != null)
            {
                 _db.Categories.Remove(exisitingCategory);
                await _db.SaveChangesAsync();
                return exisitingCategory;
            }
            return null;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync(); ;
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await _db.Categories.FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
           var existingCategory = await _db.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name= category.Name;
                existingCategory.UrlHandle = category.UrlHandle;

                _db.Update(existingCategory);
                await _db.SaveChangesAsync();

                return category;
            }
           
              return null;
            
          

        }
    }
}
