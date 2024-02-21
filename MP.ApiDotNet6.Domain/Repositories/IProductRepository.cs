
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task<ICollection<Product>> GetAll();
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);

        Task<int> GetByCodErp(string codErp);
    }
}
