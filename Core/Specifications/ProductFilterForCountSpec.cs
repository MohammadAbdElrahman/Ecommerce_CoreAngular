using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
  public class ProductFilterForCountSpec: BaseSpecification<Product>

    {
        public ProductFilterForCountSpec(ProductSpecParams productParams)   
            :base(
                 p =>
                 (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search))
                 &&
                 (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId)
                 &&
                 (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)

                 )
        {
        }
     
   
     

}
}
