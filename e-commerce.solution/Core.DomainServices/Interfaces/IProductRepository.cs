using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

    }
}
