using CodePulse.API.Validators;

namespace CodePulse.API.DTOs.CategoryDTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string UrlHandle { get; set; }
    }
}
