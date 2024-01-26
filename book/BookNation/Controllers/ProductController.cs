using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            foreach (var prod in products)
            {
                prod.Author = await _context.Authors.Where(x => x.ProductId == prod.Id).ToListAsync();
                prod.ApplicableField = await _context.ApplicableFields.Where(x => x.ProductId == prod.Id).ToListAsync();
            }
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }


        // https://www.takealot.com/principles-of-information-security/PLID42205851
        [HttpPost("add")]
        public async Task<ActionResult<ProductDto>> Add(ProductDto productDto)
        {
            var product = new Product
            {
                ApplicableField = new List<ApplicableField>(),
                Author = new List<Author>()
            };

            foreach (var item in productDto.ApplicableField)
            {
                product.ApplicableField.Add(new ApplicableField
                {
                    Name = item.Name,
                    Description = item.Description
                });
            }

            foreach (var item in productDto.Author)
            {
                product.Author.Add(new Author
                {
                    Name = item.Name,
                    Surname = item.Surname
                });
            }

            product.Name = productDto.Name;
            product.Barcode = productDto.Barcode;
            product.CategoryId = productDto.CategoryId;
            product.Edition = productDto.Edition;
            product.Format = productDto.Format;
            product.Language = productDto.Language;
            product.PageCount = productDto.PageCount;
            product.Price = productDto.Price;
            product.Publisher = productDto.Publisher;
            product.PublishedDate = productDto.PublishedDate;
            product.StockQuantity = productDto.StockQuantity;
            product.Volume = productDto.Volume;


            _context.Products.Add(product);
            await _context.SaveChangesAsync();


            var resProduct = new ProductDto
            {
                Author = new List<AuthorDto>(),
                ApplicableField = new List<ApplicableFieldDto>()
            };

            foreach (var item in product.ApplicableField)
            {
                resProduct.ApplicableField.Add(new ApplicableFieldDto
                {
                    Name = item.Name,
                    Description = item.Description
                });
            }
            foreach (var item in product.Author)
            {
                resProduct.Author.Add(new AuthorDto
                {
                    Name = item.Name,
                    Surname = item.Surname
                });
            }
            resProduct.Name = product.Name;
            resProduct.Barcode = product.Barcode;
            resProduct.CategoryId = product.CategoryId;
            resProduct.Edition = product.Edition;
            resProduct.Format = product.Format;
            resProduct.Language = product.Language;
            resProduct.PageCount = product.PageCount;
            resProduct.Price = product.Price;
            resProduct.Publisher = product.Publisher;
            resProduct.PublishedDate = product.PublishedDate;
            resProduct.StockQuantity = product.StockQuantity;
            resProduct.Volume = product.Volume;

            return resProduct;
        }

    }
}