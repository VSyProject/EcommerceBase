using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Services
{
    public class ProductService : EcommerceServices<Product>, IProductSevice
    {
        private readonly IProductReponsitory _productReponsitory;
        private readonly IMapper _mapper;

        public ProductService(IProductReponsitory productReponsitory, IMapper mapper) : base(productReponsitory)
        {
            _productReponsitory = productReponsitory;
            _mapper = mapper;
            this._productReponsitory = productReponsitory;
        }

        public async Task<List<ProductViewModel>> GetProductByCategoryIdAndOrderByView(Guid categoryId)
        {
            var product = await _productReponsitory.GetProductByCategoryIdAndOrderByView(categoryId);
            return _mapper.Map<List<ProductViewModel>>(product);
        }

        public async Task<bool> GrowUpViewByProductId(Guid productId)
        {
            return await _productReponsitory.GrowUpViewByProductId(productId);
        }
    }
}
