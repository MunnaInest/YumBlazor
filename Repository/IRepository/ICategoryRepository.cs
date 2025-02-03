using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> GetAsync(int categoryId);
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> CreateCategoryAsync(Category category);
        public Task<Category> UpdateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(int id);
    }
}
