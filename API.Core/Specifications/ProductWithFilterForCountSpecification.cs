using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Specifications
{
    public class ProductWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFilterForCountSpecification(ProductSpecParams productSpecParams) : base(x =>
        (!productSpecParams.BrandId.HasValue || x.ProdutBrandId == productSpecParams.BrandId)
        &&
        (!productSpecParams.TypeId.HasValue || x.ProdutBrandId == productSpecParams.TypeId))
        {


        }
    }
}
