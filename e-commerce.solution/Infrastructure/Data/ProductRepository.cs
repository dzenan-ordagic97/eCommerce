using Core.Domain.Entities;
using Core.DomainServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly eCommerceContext _context;

        public ProductRepository(eCommerceContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return (IReadOnlyList<ProductBrand>)await _context.ProductBrand.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {

            return await _context.Product
                .Include(x => x.ProductBrand)
                .Include(x => x.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Product
                .Include(x=> x.ProductBrand)
                .Include(x=> x.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return (IReadOnlyList<ProductType>)await _context.ProductType.ToListAsync();
        }
    }
}
