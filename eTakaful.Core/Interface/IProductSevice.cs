using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Interface
{
    public  interface IProductSevice : IServices<Product>
    {
        Task<List<ProductViewModel>> GetProductByCategoryIdAndOrderByView(Guid categoryId);
        Task<bool> GrowUpViewByProductId(Guid productId);
    }
}
