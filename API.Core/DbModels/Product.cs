namespace API.Core.DbModels
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string PictureUrl{ get; set; }

        public ProductType ProdutType { get; set; }
        public int? ProdutTypeId { get; set; }

        public ProductBrand ProdutBrand { get; set; }
        public int? ProdutBrandId { get; set; }
    }
}
