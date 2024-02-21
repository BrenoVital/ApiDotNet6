using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;
        public PurchaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Purchase> Create(Purchase purchase)
        {
            _db.Add(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> Delete(Purchase purchase)
        {
            _db.Remove(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }

        public async Task<Purchase> GetById(int id)
        {
            return await _db.Purchases.Include(p => p.Person).Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Purchase>> GetAll()
        {
            return await _db.Purchases.Include(p => p.Person).Include(p => p.Product).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByPersonId(int personId)
        {
            return await _db.Purchases.Include(p => p.Person).Include(p => p.Product).Where(p => p.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByProductId(int productId)
        {
            return await _db.Purchases.Include(p => p.Product).Include(p => p.Person).Where(p => p.ProductId == productId).ToListAsync();
        }

        public async Task<Purchase> Update(Purchase purchase)
        {
            _db.Update(purchase);
            await _db.SaveChangesAsync();
            return purchase;
        }
    }
}
