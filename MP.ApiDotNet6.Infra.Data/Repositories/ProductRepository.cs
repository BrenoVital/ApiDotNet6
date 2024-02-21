
using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Create(Product product)
        {
            _db.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<int> GetByCodErp(string codErp)
        {
            return (await _db.Products.FirstOrDefaultAsync(p => p.CodErp == codErp))?.Id ?? 0;
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
            _db.Update(product);
            await _db.SaveChangesAsync();
            return product;
        }
    }
}
