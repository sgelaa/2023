using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class CategoriesController : BaseApiController
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> CategoriesList()
        {
            var temp = await _context.Categories.ToListAsync();

            List<CategoryDto> categories = new List<CategoryDto>();
            temp.ForEach(x =>
            {
                categories.Add(new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                });
            });

            return categories;
        }

        [HttpGet("detailed")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            categories.ForEach(async item =>
            {
                item.Products = await _context.Products.Where(prod => prod.CategoryId == item.Id).ToListAsync();
                foreach (var product in item.Products)
                {
                    product.Author = await _context.Authors.Where(x => x.ProductId == product.Id).ToListAsync();
                    product.ApplicableField = await _context.ApplicableFields.Where(x => x.ProductId == product.Id).ToListAsync();
                }
            });
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryDetail(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        [HttpPost("add")]
        public async Task<ActionResult<CategoryDto>> Add(string name)
        {
            if (await CategoryNameExists(name))
            {
                return BadRequest("Category name already exists");
            }

            var category = new Category
            {
                Name = name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryDto
            {
                Name = category.Name,
            };
        }

        private async Task<bool> CategoryNameExists(string name)
        {
            return await _context.Categories.AnyAsync(cat => cat.Name == name.ToLower());
        }

    }
}