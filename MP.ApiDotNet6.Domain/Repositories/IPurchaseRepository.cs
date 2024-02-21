

using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> Create(Purchase purchase);
        //Task<Purchase> Update(Purchase purchase);
        //Task<Purchase> Delete(Purchase purchase);
        Task<ICollection<Purchase>> GetAll();
        Task<Purchase> GetById(int id);

    }
}
