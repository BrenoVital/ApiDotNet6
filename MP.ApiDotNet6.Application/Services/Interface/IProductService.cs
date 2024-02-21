using MP.ApiDotNet6.Application.DTOs;

namespace MP.ApiDotNet6.Application.Services.Interface
{
    public interface IProductService
    {
        Task<ResultService<ProductDTO>> Create(ProductDTO product);
        Task<ResultService<ProductDTO>> Update(ProductDTO product);
        Task<ResultService<ProductDTO>> Delete(int id);
        Task<ResultService<ProductDTO>> GetById(int id);
        Task<ResultService<ICollection<ProductDTO>>> GetAll();
    }
}
