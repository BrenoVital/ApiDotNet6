
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Validations;
using MP.ApiDotNet6.Application.Services.Interface;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotNet6.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> Create(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Produto não pode ser nulo");

            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Problema na validação,", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.Create(product);
            return ResultService.Ok(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService<ProductDTO>> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return ResultService.Fail<ProductDTO>("Produto não encontrado");
            }
            await _productRepository.Delete(product);
            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return ResultService.Ok(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return ResultService.Fail<ProductDTO>("Produto não encontrado");
            }
            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService<ProductDTO>> Update(ProductDTO product)
        {
            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto deve ser informado!");

            var validation = new ProductDTOValidator().Validate(product);
            if (!validation.IsValid)
                return ResultService.RequestError<ProductDTO>("Problema na validação", validation);

            var result = await _productRepository.GetById(product.Id);
            if (result == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado");

            result = _mapper.Map(product, result);
            await _productRepository.Update(result);
            return ResultService.Ok(_mapper.Map<ProductDTO>(result));
        }
    }
}
