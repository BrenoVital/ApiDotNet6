using AutoMapper;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Validations;
using MP.ApiDotNet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PurchaseDTO>> Create(PurchaseDTO purchase)
        {
            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");
            
            var validate = new PurchaseDTOValidator().Validate(purchase);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);

            var productId = await _productRepository.GetByCodErp(purchase.CodErp);
            var personId = await _personRepository.GetByDocument(purchase.Document);

            var result = new Purchase(productId, personId);
            var data = await _purchaseRepository.Create(result);
            purchase.Id = data.Id;
            return ResultService.Ok(purchase);
        }

        public async Task<ResultService<PurchaseDTO>> Delete(int id)
        {
            var purchase = await _purchaseRepository.GetById(id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");

            await _purchaseRepository.Delete(purchase);
            return (ResultService<PurchaseDTO>)ResultService.Ok("Compra deletada");
        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAll()
        {
            var purchases = await _purchaseRepository.GetAll();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }
        public async Task<ResultService<PurchaseDetailDTO>> GetById(int id)
        {
            var purchase = await _purchaseRepository.GetById(id);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailDTO>("Compra não encontrada");
           
            return ResultService.Ok(_mapper.Map<PurchaseDetailDTO>(purchase));
        }
        public async Task<ResultService<PurchaseDTO>> Update(PurchaseDTO purchase)
        {
            if(purchase == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");

            var validate = new PurchaseDTOValidator().Validate(purchase);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problemas de validação", validate);

            var result = await _purchaseRepository.GetById(purchase.Id);
            if (result == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada");

            var productId = await _productRepository.GetByCodErp(purchase.CodErp);
            var personId = await _personRepository.GetByDocument(purchase.Document);
            result.Edit(purchase.Id, productId, personId);
            await _purchaseRepository.Update(result);
            return ResultService.Ok(purchase);

        }
    }
}
