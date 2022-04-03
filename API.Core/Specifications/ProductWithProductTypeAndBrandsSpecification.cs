using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecification()
        {
            AddInclude(x => x.ProdutBrand);
            AddInclude(x => x.ProdutType);
        }
    }
}
