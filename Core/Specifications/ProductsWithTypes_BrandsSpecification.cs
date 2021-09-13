using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypes_BrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypes_BrandsSpecification(ProductSpecParams productParams)
            : base(
                 p =>
                 (string.IsNullOrEmpty(productParams.Search)||p.Name.ToLower().Contains(productParams.Search))
                 &&
                 (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
                 &&
                 (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)

                 )
        {
            AddInclde(p => p.ProductType);
            AddInclde(p => p.ProductBrand);
            AddOrderBy(p => p.Name);
            AddPaging(productParams.PageSize ,productParams.PageSize * (productParams.PageIndex - 1));

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithTypes_BrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclde(p => p.ProductType);
            AddInclde(p => p.ProductBrand);

        }
    }
}
