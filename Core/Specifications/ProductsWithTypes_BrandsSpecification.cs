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
        public ProductsWithTypes_BrandsSpecification()
        {
            AddInclde(p=>p.ProductType);
            AddInclde(p=>p.ProductBrand);
        }

        public ProductsWithTypes_BrandsSpecification(int id) : base(p=>p.Id==id)
        { AddInclde(p=>p.ProductType);
            AddInclde(p=>p.ProductBrand);
       
        }
    }
}
