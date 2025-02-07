using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> GetAsync(int ProductId);
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> CreateProductAsync(Product Product);
        public Task<Product> UpdateProductAsync(Product Product);
        public Task<bool> DeleteProductAsync(int id);
    }
}
