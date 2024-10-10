using Cadastro.Domain.Entities;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Cadastro.Domain.Interfaces;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IProductRepository _productRepository;

        public ProductViewModelService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel Get(int id)
        {
            var product = _productRepository.Get(id);
            return MapToViewModel(product);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            return products.Select(MapToViewModel);
        }

        public void Insert(ProductViewModel viewModel)
        {
            var product = MapToEntity(viewModel);
            _productRepository.Insert(product);
        }

        public void Update(ProductViewModel viewModel)
        {
            var product = MapToEntity(viewModel);
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        private ProductViewModel MapToViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                Active = product.Active,
                ClientId = product.ClientId,
                ClientName = product.Client != null ? product.Client.Name : "Sem Cliente"
            };
        }

        private Product MapToEntity(ProductViewModel viewModel)
        {
            if (!viewModel.ClientId.HasValue)
            {
                throw new InvalidOperationException("ClientId is required when creating a Product.");
            }

            return new Product
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Value = viewModel.Value,
                Active = viewModel.Active,
                ClientId = viewModel.ClientId.Value
            };
        }
    }
}
