using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interface
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> Create(PurchaseDTO purchase);
        //Task<ResultService<PurchaseDTO>> Update(PurchaseDTO purchase);
        //Task<ResultService<PurchaseDTO>> Delete(int id);
        Task<ResultService<PurchaseDetailDTO>> GetById(int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAll();
    }
}
