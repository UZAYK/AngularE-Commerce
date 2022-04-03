using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
        : base(x =>
        (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
        &&
        (!productSpecParams.BrandId.HasValue || x.ProdutBrandId == productSpecParams.BrandId)
        &&
        ///HasValue = "var ise"
        (!productSpecParams.TypeId.HasValue || x.ProdutBrandId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProdutBrand);
            AddInclude(x => x.ProdutType);
            AddOrderBy(x => x.Name);

            //önce gelen sayfanın örn:2, bir eksisini alarak(geçilen sayfasının saptanması için), onu listenen 
            //sayfa botuyu(listenilen kayır sayısı örn: 2) ile çarpar(geçeceği kayıt sayısı), en son ki ibare de alacağı sayfa sayısı
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            ///bir değer girilmiş ise ve bu değer mantıklı bir şey ise;
            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
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
