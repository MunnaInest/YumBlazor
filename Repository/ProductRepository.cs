using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment = null)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;   
        }
        public async Task<Product> CreateProductAsync(Product Product)
        {
            await _db.Product.AddAsync(Product);
            await _db.SaveChangesAsync();
            return Product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            int count = 0;
            var obj = _db.Product.Find(id);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));
            if(File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            if (obj != null) {
                _db.Product.Remove(obj);
                count = await _db.SaveChangesAsync();
            }
            return count > 0;
        }

        public async Task<Product> GetAsync(int ProductId)
        {
            int count = 0;  
            var Product = await _db.Product.FindAsync(ProductId);
            if (Product != null)
            {
                count = _db.SaveChanges();
            }
            return Product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product.Include(u => u.Category).ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product Product)
        {
            int count = 0;
            var obj = await _db.Product.FirstOrDefaultAsync(u => u.Id == Product.Id);
            if (obj is not null)
            {
                obj.Name = Product.Name;
                obj.Price = Product.Price;
                obj.Description = Product.Description;
                obj.SpecialTag = Product.SpecialTag;
                obj.CategoryId = Product.CategoryId;
                obj.ImageUrl = Product.ImageUrl;
                _db.Product.Update(obj);   
                count = await _db.SaveChangesAsync();
            }
            return obj;
        }
    }
}
