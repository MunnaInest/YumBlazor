using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            int count = 0;
            var category = _db.Category.Find(id);
            if (category != null)
            {
                _db.Category.Remove(category);
                count = await _db.SaveChangesAsync();
            }
            return count > 0;
        }

        public async Task<Category> GetAsync(int categoryId)
        {
            int count = 0;
            var category = await _db.Category.FindAsync(categoryId);
            if (category != null)
            {
                count = _db.SaveChanges();
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            int count = 0;
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == category.Id);
            if (obj is not null)
            {
                obj.Name = category.Name;
                _db.Category.Update(obj);
                count = await _db.SaveChangesAsync();
            }
            return obj;
        }
    }
}
