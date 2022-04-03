using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecification(string sort)
        {
            AddInclude(x => x.ProdutBrand);
            AddInclude(x => x.ProdutType);
            AddOrderBy(x => x.Name);

            ///bir değer girilmiş ise ve bu değer mantıklı bir şey ise;
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;

                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
        public ProductWithProductTypeAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProdutBrand);
            AddInclude(x => x.ProdutType);
        }
    }
}
